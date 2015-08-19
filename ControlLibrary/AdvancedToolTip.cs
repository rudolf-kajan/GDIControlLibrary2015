using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using ControlLibrary.DrawComponents;

namespace ControlLibrary
{
    public partial class AdvancedToolTip : UserControl
    {
        private ISkinProvider _skin;
              
        private readonly List<DrawComponent> _drawComponents;
        private readonly MouseGestureRecognizer _mouseGestureRecognizer;
        
        public AdvancedToolTip()
        {
            InitializeComponent();

            #region Set Visual Style hints
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ContainerControl, false);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, false);
            SetStyle(ControlStyles.Opaque, true);
            #endregion

            #region Set up mouse gesture recognizer
            _mouseGestureRecognizer = new MouseGestureRecognizer();
            _mouseGestureRecognizer.OnInputRecognized += MouseInputRecognized;
#endregion

            ChangeSkin(new MaterialOrangeSkin());

            // http://stackoverflow.com/questions/22735174/how-to-write-winforms-code-that-auto-scales-to-system-font-and-dpi-settings
            AutoScaleDimensions = new SizeF(6F, 13F);
            
            // most basic tooltip container
            _drawComponents = new List<DrawComponent>(10);

            // as a test fill component with test items
            AddIndividualComponents();
        }

        private void AddIndividualComponents()
        {
            // apply basic formatting in the form of vertical stack
            VerticalStack verticalStack = new VerticalStack(new Size(Width, 400));

            verticalStack.AddChild(new HeaderComponent());

            verticalStack.AddChild(new ToggleComponent
            {
                TextLabel = "Zaškrtnuto",
                ToggleState = ToggleStateEnum.On
            });

            verticalStack.AddChild(new ToggleComponent
            {
                TextLabel = "Nezaškrtnuto",
                ToggleState = ToggleStateEnum.Off
            });

            verticalStack.AddChild(new LabelComponent
            {
                TextLabel = "Počet lidí",
                TextValue = "158"
            });

            verticalStack.AddChild(new DescriptionComponent
            {
                TextLabel = "Popis",
                TextValue = "The path of the righteous man is beset on all sides by the iniquities " +
                            "of the selfish and the tyranny of evil men. Blessed is he who, in the name " +
                            "of charity and good will, shepherds the weak through the valley of darkness, " +
                            "for he is truly his brother's keeper and the finder of lost children. And I " +
                            "will strike down upon thee with great vengeance and furious anger those who " +
                            "would attempt to poison and destroy My brothers. And you will know My name is " +
                            "the Lord when I lay My vengeance upon thee."
            });

            verticalStack.AddChild(new ImageGalleryPreviewComponent
            {
                Icons = new List<Image>
                {
                    Resource.Snow0, Resource.Snow1, Resource.Snow2, Resource.Snow0, Resource.Snow1, Resource.Snow2
                }
            });

            verticalStack.AddChild(new IconLabelComponent
            {
                Icon = Resource.PDF_100,
                TextLabel = "Priloha.pdf",
                TextValue = "320 kB"
            });

            verticalStack.AddChild(new IconLabelComponent
            {
                Icon = Resource.DOC_100,
                TextLabel = "Wordovy dokument.pdf",
                TextValue = "534 kB"
            });

            verticalStack.AddChild(new IconActionBarComponent
            {
                Icons = new List<Image>
                {
                    Resource.Open_Folder_100, Resource.Checked_Checkbox_2_100, Resource.More_100
                },

                Actions = new List<Action>
                {
                    (()=> { MessageBox.Show(@"Fired action #1"); }),
                    (()=> { MessageBox.Show(@"Fired action #2"); }),
                    (()=> { MessageBox.Show(@"Fired action #3"); }),
                }
            });


            VerticalStack topStack = new VerticalStack(new Size(Width, Height));

            topStack.AddChild(new HeaderComponent { Size = new Size(Width, 50), ZOrder = 1 });
            topStack.AddChild(verticalStack);
            topStack.AddChild(new HeaderComponent { Size = new Size(Width, 50), ZOrder = 1 });

            AddChild(topStack);
        }

        public void ChangeSkin(ISkinProvider skin)
        {
            _skin = skin;
            Refresh();
        }

        public void AddChild(DrawComponent drawComponent)
        {
            _drawComponents.Add(drawComponent);
        }

        public void ClearChildren(DrawComponent drawComponent)
        {
            _drawComponents.Clear();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            pe.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            foreach (DrawComponent drawComponent in _drawComponents)
                drawComponent.OnPaint(pe, _skin);
        }

        private void AdvancedToolTip_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseGestureRecognizer.OnMouseDown(sender, e);
        }

        private void AdvancedToolTip_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseGestureRecognizer.OnMouseUp(sender, e);
        }

        private void AdvancedToolTip_MouseMove(object sender, MouseEventArgs e)
        {
            _mouseGestureRecognizer.OnMouseMove(sender, e);
        }

        private void MouseInputRecognized(InputType inputType, MouseEventArgs beginArgs, MouseEventArgs endArgs, object args)
        {
            foreach (DrawComponent drawComponent in _drawComponents)
            {
                if (drawComponent is IInputEnabled && Utils.IsInputStartInBounds(drawComponent, beginArgs))
                {
                    InputResult result = (drawComponent as IInputEnabled).OnInput(inputType, beginArgs, endArgs, args);
                    Refresh();

                    if (result == InputResult.Consumed)
                        break;
                }
            }
        }
    }
}

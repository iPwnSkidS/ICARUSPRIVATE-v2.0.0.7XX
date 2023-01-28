using ShitarusPrivate.JCS;

namespace ShitarusPrivate.ToggleSwitch
{
    public class BeforeRenderingEventArgs
    {
        public ToggleSwitchRendererBase Renderer { get; set; }

        public BeforeRenderingEventArgs(ToggleSwitchRendererBase renderer)
        {
            Renderer = renderer;
        }
    }
}

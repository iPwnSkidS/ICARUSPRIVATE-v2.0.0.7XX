using System.Drawing;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Ambience
{
    public class AmbianceLinkLabel : LinkLabel
    {
        public AmbianceLinkLabel()
        {
            Font = new Font("Segoe UI", 11f, FontStyle.Regular);
            BackColor = Color.Transparent;
            base.LinkColor = Color.FromArgb(240, 119, 70);
            base.ActiveLinkColor = Color.FromArgb(221, 72, 20);
            base.VisitedLinkColor = Color.FromArgb(240, 119, 70);
            base.LinkBehavior = LinkBehavior.AlwaysUnderline;
        }
    }
}

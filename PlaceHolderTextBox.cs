using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace TeamsContactsGroupCreator
{
    class PlaceHolderTextBox : TextBox
    {
        bool isPlaceHolder = true;
        string _placeHolderText;
        public string PlaceHolderText
        {
            get { return _placeHolderText; }
            set
            {
                _placeHolderText = value;
                setPlaceholder();
            }
        }

        public new string Text
        {
            get { return isPlaceHolder ? string.Empty : base.Text; }
            set { base.Text = value; }
        }

        //when the control loses focus, the placeholder is shown
        private void setPlaceholder()
        {
            if (string.IsNullOrEmpty(base.Text))
            {
                base.Text = PlaceHolderText;
                this.Foreground = new SolidColorBrush(Colors.Gray);
                isPlaceHolder = true;
            }
        }

        //when the control is focused, the placeholder is removed
        private void removePlaceHolder()
        {
            if (isPlaceHolder)
            {
                base.Text = "";
                this.Foreground = System.Windows.SystemColors.WindowTextBrush;
                isPlaceHolder = false;
            }
        }

        public PlaceHolderTextBox()
        {
            setPlaceholder();
            GotFocus += removePlaceHolder;
            LostFocus += setPlaceholder;
        }

        private void setPlaceholder(object sender, EventArgs e)
        {
            setPlaceholder();
        }

        private void removePlaceHolder(object sender, EventArgs e)
        {
            removePlaceHolder();
        }
    }
}

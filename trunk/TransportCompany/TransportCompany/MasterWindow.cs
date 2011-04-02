using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TransportCompany
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:TransportCompany"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:TransportCompany;assembly=TransportCompany"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:MasterWindow/>
    ///
    /// </summary>
    public class MasterWindow : Control
    {
        static MasterWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MasterWindow), new FrameworkPropertyMetadata(typeof(MasterWindow)));
        }
        
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(object), typeof(MasterWindow),new UIPropertyMetadata());

        public Object Header
        {
            set
            {
                SetValue(HeaderProperty,value); 
            }
            get
            {
                return (object)GetValue(HeaderProperty);
            }
        }

        public static readonly DependencyProperty SideMenuContentProperty = DependencyProperty.Register("SideMenuContent", typeof(object), typeof(MasterWindow), new UIPropertyMetadata());

        public Object SideMenuContent
        {
            set
            {
                SetValue(SideMenuContentProperty, value);
            }
            get
            {
                return (object)GetValue(SideMenuContentProperty);
            }
        }

        public static readonly DependencyProperty MainContentProperty = DependencyProperty.Register("MainContent", typeof(object), typeof(MasterWindow), new UIPropertyMetadata());

        public Object MainContent
        {
            set
            {
                SetValue(MainContentProperty, value);
            }
            get
            {
                return (object)GetValue(MainContentProperty);
            }
        }
    }
}

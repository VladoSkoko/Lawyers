using Lawyers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lawyers.SupplementalClasses;

namespace Lawyers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBoxGotFocus(TextBox TextBoxToFocus)
        {
            TextBoxToFocus.SelectAll();
        }

        private void tbLawyerSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxGotFocus(tbLawyerSearch);
        }

        private void tbLawyerSearch_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBoxGotFocus(tbLawyerSearch);
        }

        private void tbLawyerSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListViewSearch(tbLawyerSearch.Text, lvLawyer, RefreshLawyer);
        }

        private void tbLawyerName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxGotFocus(tbLawyerName);
        }

        private void btnCancelLawyer_Click(object sender, RoutedEventArgs e)
        {
            ClearLawyer();
        }

        private void btnAddLawyer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!ValidateLawyer())
                    return;

                Lawyer l = new Lawyer
                {
                    Name = tbLawyerName.Text
                };

                l.Add();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tbCompanySearch_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxGotFocus(tbCompanySearch);
        }

        private void tbCompanySearch_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBoxGotFocus(tbCompanySearch);
        }

        private void tbCompanySearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListViewSearch(tbCompanySearch.Text, lvCompany, RefreshCompany);
        }

        private void btnAddCompany_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!ValidateCompany())
                    return;

                Company c = new Company
                {
                    Name = tbCompanyName.Text
                };

                c.Add();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelCompany_Click(object sender, RoutedEventArgs e)
        {
            ClearCompany();
        }

        private void tbMatterSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxGotFocus(tbMatterSearch);
        }

        private void tbMatterSearch_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBoxGotFocus(tbMatterSearch);
        }

        private void tbMatterSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListViewSearch(tbMatterSearch.Text, lvMatter, RefreshMatter);
        }

        private void tbMatterName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxGotFocus(tbMatterName);
        }

        private void btnAddMatter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!ValidateMatter())
                    return;

                Matter m = new Matter
                {
                    Name = tbMatterName.Text,
                    CompanyID = ((Company)cbCompanyM.SelectedItem).CompanyID
                };

                m.Add();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelMatter_Click(object sender, RoutedEventArgs e)
        {
            ClearMatter();
        }

        private void tbSubmatterSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxGotFocus(tbSubmatterSearch);
        }

        private void tbSubmatterSearch_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBoxGotFocus(tbSubmatterSearch);
        }

        private void tbSubmatterSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListViewSearch(tbSubmatterSearch.Text, lvSubmatter, RefreshSubmatter);
        }

        private void cbCompanyS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCompanyS.SelectedItem == null)
                return;
            cbMatterS.ItemsSource = Matter.GetMattersByCompanyID(((Company)cbCompanyS.SelectedItem).CompanyID);
        }

        private void btnAddSubmatter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!ValidateSubmatter())
                    return;

                Submatter s = new Submatter
                {
                    Name = tbSubmatterName.Text,
                    MatterID = ((Matter)cbMatterS.SelectedItem).MatterID,
                };

                s.Add();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelSubmatter_Click(object sender, RoutedEventArgs e)
        {
            ClearSubmatter();
        }

        private void cbCompanyT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCompanyT.SelectedItem == null)
                return;
            cbMatterT.ItemsSource = Matter.GetMattersByCompanyID(((Company)cbCompanyT.SelectedItem).CompanyID);
        }

        private void cbMatterT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbMatterT.SelectedItem == null)
                return;
            cbSubmatterT.ItemsSource = Submatter.GetSubmattersByMatterID(((Matter)cbMatterT.SelectedItem).MatterID);
        }

        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!ValidateTask())
                    return;

                Entities.Task t = new Entities.Task
                {
                    LawyerID = ((Lawyer)cbLawyerT.SelectedItem).LawyerID,
                    SubmatterID = ((Submatter)cbSubmatterT.SelectedItem).SubmatterID,
                    Date = dpDateT.SelectedDate.Value,
                    BillableTime = int.Parse(tbBillableMins.Text)
                };

                if (!EntryValidation.IsEmpty(tbDescriptionT.Text))
                    t.Description = tbDescriptionT.Text;

                t.Add();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelTask_Click(object sender, RoutedEventArgs e)
        {
            ClearTask();
        }

        private void tbBillableMins_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxGotFocus(tbBillableMins);
        }

        private void tbDescriptionT_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxGotFocus(tbDescriptionT);
        }

        private void lvLawyer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void lvCompany_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void lvMatter_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void lvSubmatter_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void dgTask_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void tbCompanyName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxGotFocus(tbCompanyName);
        }

        private void tbSubmatterName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxGotFocus(tbSubmatterName);
        }

        private delegate void RefreshFunction();
        private void ListViewSearch(string Text, ListView ListViewToSearch, RefreshFunction RefreshFunction)
        {
            if (EntryValidation.IsEmpty(Text))
            {
                for (int i = ListViewToSearch.Items.Count - 1; i >= 0; i--)
                {
                    var item = ListViewToSearch.Items.GetItemAt(i);
                    if (!item.ToString().ToLower().Contains(Text.ToLower()))
                    {
                        ListViewToSearch.Items.Remove(item);
                    }
                }
            }
            else
            {
                RefreshFunction();
            }
        }

        private void RefreshLawyer()
        {
            lvLawyer.ItemsSource = Lawyer.GetLawyers();
        }

        private void RefreshCompany()
        {
            lvCompany.ItemsSource = Company.GetCompanies();
        }

        private void RefreshMatter()
        {
            lvMatter.ItemsSource = Matter.GetMatters();
        }

        private void RefreshSubmatter()
        {
            lvSubmatter.ItemsSource = Submatter.GetSubmatters();
        }

        private void ClearLawyer()
        {
            tbLawyerName.Text = string.Empty;
        }

        private void ClearCompany()
        {
            tbCompanyName.Text = string.Empty;
        }

        private void ClearMatter()
        {
            tbMatterName.Text = string.Empty;
            cbCompanyM.SelectedItem = null;
        }

        private void ClearSubmatter()
        {
            tbSubmatterName.Text = string.Empty;
            cbCompanyS.SelectedItem = null;
        }

        private void ClearTask()
        {
            cbLawyerT.SelectedItem = null;
            cbCompanyT.SelectedItem = null;
            dpDateT.SelectedDate = DateTime.Now;
            tbBillableMins.Text = string.Empty;
            tbDescriptionT.Text = string.Empty;
        }

        private bool ValidateTask()
        {
            return true;
        }
        private bool ValidateCompany()
        {
            return true;
        }
        private bool ValidateMatter()
        {
            return true;
        }
        private bool ValidateSubmatter()
        {
            return true;
        }
        private bool ValidateLawyer()
        {
            return true;
        }
    }
}

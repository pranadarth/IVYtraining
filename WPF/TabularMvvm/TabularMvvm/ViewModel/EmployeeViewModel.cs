using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabularMvvm.Model;
using TabularMvvm.View;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;

namespace TabularMvvm.ViewModel
{
    public class EmployeeViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        static String connectionString = @"Data Source=INLPF3KSCQM;Initial Catalog=Practice;Integrated Security=True;";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataSet ds;

        private EmployeeData _employee;

        public EmployeeData employeeData
        {
            get { return _employee; }
            set 
            { 
                _employee = value; 
                OnPropertyChange(nameof(employeeData));
            }
        }

      private ObservableCollection<EmployeeData>  _eData;


        public ObservableCollection<EmployeeData> eData
        {
            get { return _eData; }
            set
            {
                _eData = value;
                OnPropertyChange(nameof(eData));
            }
        }

        private Visibility _visible;
        public Visibility EditPgVisible
        {
            get { return _visible; }
            set { _visible = value; OnPropertyChange(nameof(EditPgVisible)); }
        }

        private double _blur;
        public double BlurValue
        {
            get { return _blur; }
            set { _blur = value; OnPropertyChange(nameof(BlurValue)); }
        }

        private EmployeeData _selected;
        public EmployeeData Selected 
        {
            get { return _selected; }
            set { _selected= value; OnPropertyChange(nameof(Selected));}
        }

        public EmployeeViewModel()
        {
            EditPgVisible = Visibility.Collapsed;
            BlurValue= 0;
            FillData();
            OkBtn = new RelayCommand( Ok, canOkbuttonExce);
            DeleteBtn = new RelayCommand( Delete, CanExec );
            EditBtn = new RelayCommand( Edit, CanExec );
            ResetBtn = new RelayCommand( Reset, CanExec );
        }

        private bool canOkbuttonExce(object arg)
        {
            return true;
        }

        private bool CanExec(object value)
        {
           if(EditPgVisible == Visibility.Collapsed)
            return true;
          
            return false;
        }

        public void FillData()
        {
            try
            {
                con = new SqlConnection(connectionString);
                con.Open();
                cmd = new SqlCommand("select * from officeData Order by EName", con);
                adapter = new SqlDataAdapter(cmd);
                ds = new DataSet();
                adapter.Fill(ds, "office");

                //if (eData == null)
                    eData = new ObservableCollection<EmployeeData>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    eData.Add(new EmployeeData
                    {
                        Id = long.Parse(dr[0].ToString()),
                        Name = dr[1].ToString(),
                        Role = dr[2].ToString()
                    });
                }
                con.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ICommand ResetBtn { get; set; }

        private void Reset(Object value)
        {
            FillData();
        }

        public ICommand EditBtn { get; set; }
        
        private void Edit(Object value)
        {
            Selected = value as EmployeeData;

           EditPgVisible = Visibility.Visible;
            BlurValue = 30;
        }

        public ICommand DeleteBtn { get; set; }

        private void Delete(Object value)
        {
            var obj = (EmployeeData)value;

            con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand("DeleteOfficeData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eId", SqlDbType.BigInt).Value = obj.Id;
            cmd.ExecuteNonQuery();
            con.Close();

           // eData.Remove(obj);
            FillData();
        }

        public ICommand OkBtn { get; set; }

        private void Ok(object value)
        {
            EditPgVisible = Visibility.Collapsed;
            BlurValue = 0;


            con.Open();
            cmd = new SqlCommand("EditOfficeData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eId", SqlDbType.BigInt).Value = Selected.Id;
            cmd.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = Selected.Name;
            cmd.Parameters.AddWithValue("@Desig", SqlDbType.NVarChar).Value = Selected.Role;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

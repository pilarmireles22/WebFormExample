using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormCrud.Service;
using WebFormCrud.Model;
using System.Data;
namespace WebFormCrud
{
    public partial class EmployeeForm : System.Web.UI.Page
    { private EmployeeService _employeeService;
        public EmployeeForm()
        {
            _employeeService = new EmployeeService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillView();
                Clear();
                btnDelete.Enabled = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.EmployeeID = hfEmployeeID.Value==""?0:Convert.ToInt32(hfEmployeeID.Value.ToString());
            employee.FirstName = txtFirstName.Text.Trim();
            employee.LastName = txtLastName.Text.Trim();
            employee.SecondLastName = txtSecondLastName.Text.Trim();
            employee.Phone = txtPhone.Text.Trim();
            employee.Email = txtEmail.Text.Trim();
            employee.Address = txtAddress.Text.Trim();
            _employeeService.CreateOrUpdateEmployee(employee);
            if (hfEmployeeID.Value=="")
            {
                lblSuccessMessage.Text = "Save Succefully";
            }
            else
            {
                lblSuccessMessage.Text = "Update Succefully";
            }
            FillView();
            Clear();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            _employeeService.DeleteEmployeeByID(Convert.ToInt32(hfEmployeeID.Value));
            if (hfEmployeeID.Value=="")
            {
                lblSuccessMessage.Text = "Delete succefuly";
            }
            FillView();
            Clear();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            btnDelete.Enabled = true;
            lblSuccessMessage.Text = lblErrorMessage.Text = "";
            txtFirstName.Text = txtLastName.Text = txtSecondLastName.Text = txtPhone.Text = txtEmail.Text = txtAddress.Text = "";

        }
         void  FillView()
        {

            gvEmployee.DataSource = _employeeService.GetAllEmployees();
            gvEmployee.DataBind();
        }
        protected void lnk_OnClick(object sender, EventArgs e)
        {
            int EmployeeID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Employee employee= _employeeService.GetEmployeeByID(EmployeeID);
            hfEmployeeID.Value = employee.EmployeeID.ToString();
            txtFirstName.Text = employee.FirstName;
            txtLastName.Text = employee.LastName;
            txtSecondLastName.Text = employee.SecondLastName;
            txtPhone.Text = employee.Phone;
            txtEmail.Text = employee.Email;
            txtAddress.Text = employee.Address;
            btnSave.Text = "Update";
            btnDelete.Enabled = true;
        }
    }
}
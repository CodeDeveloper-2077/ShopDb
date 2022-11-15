using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using User_Interface.Forms;

namespace User_Interface
{
    public partial class MainForm : Form
    {
        private readonly CitiesForm _cities;
        private readonly CustomerOrdersForm _customerOrders;
        private readonly CustomersForm _customers;
        private readonly OrderDetailsForm _orderDetails;
        private readonly PersonalContactForm _personalContacts;
        private readonly PersonForm _people;
        private readonly ProductCategoriesForm _productCategories;
        private readonly ProductForm _products;
        private readonly ProductTitlesForm _productTitles;
        private readonly StreetsForm _streets;
        private readonly SupermarketsForm _supermarkets;

        public MainForm()
        {
            _cities = new CitiesForm();
            _customerOrders = new CustomerOrdersForm();
            _customers = new CustomersForm();
            _orderDetails = new OrderDetailsForm();
            _personalContacts = new PersonalContactForm();
            _people = new PersonForm();
            _productCategories = new ProductCategoriesForm();
            _products = new ProductForm();
            _productTitles = new ProductTitlesForm();
            _streets = new StreetsForm();
            _supermarkets = new SupermarketsForm();

            InitializeComponent();
        }

        private void openCustomers_Click(object sender, EventArgs e)
        {
            _customers.Show(this);
        }

        private void openCustomerOrders_Click(object sender, EventArgs e)
        {
            _customerOrders.Show(this);
        }

        private void openOrderDetails_Click(object sender, EventArgs e)
        {
            _orderDetails.Show(this);
        }

        private void openPeople_Click(object sender, EventArgs e)
        {
            _people.Show(this);
        }

        private void openPersonContacts_Click(object sender, EventArgs e)
        {
            _personalContacts.Show(this);
        }

        private void openProducts_Click(object sender, EventArgs e)
        {
            _products.Show(this);
        }

        private void openProductCategories_Click(object sender, EventArgs e)
        {
            _productCategories.Show(this);
        }

        private void openProductTitles_Click(object sender, EventArgs e)
        {
            _productTitles.Show(this);
        }

        private void openCities_Click(object sender, EventArgs e)
        {
            _cities.Show(this);
        }

        private void openStreets_Click(object sender, EventArgs e)
        {
            _streets.Show(this);
        }

        private void openSupermarkets_Click(object sender, EventArgs e)
        {
            _supermarkets.Show(this);
        }
    }
}

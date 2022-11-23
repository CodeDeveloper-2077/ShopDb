using System;
using System.Windows.Forms;
using User_Interface.Forms;
using System.Collections.Generic;
using User_Interface.Handlers;
using System.Linq;

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
        private readonly List<Control> _controls;
        private readonly ApplicationHandler _applicationHandler;
        private readonly ButtonHandler _buttonHandler;

        public MainForm()
        {
            InitializeComponent();

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

            _applicationHandler = new ApplicationHandler();
            _buttonHandler = new ButtonHandler();
            _buttonHandler.Successor = _applicationHandler;

            _controls = new List<Control>()
            {
                this,
                openCities,
                openCustomerOrders,
                openCustomers,
                openOrderDetails,
                openPersonContacts,
                openPeople,
                openProductCategories,
                openProducts,
                openProductTitles,
                openStreets,
                openSupermarkets,
            };
            foreach (var control in _controls)
                control.MouseHover += new EventHandler(control_MouseHover);
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

        private void control_MouseHover(object sender, EventArgs e)
        {
            _buttonHandler.HandleRequest(sender as Control);
        }
    }
}

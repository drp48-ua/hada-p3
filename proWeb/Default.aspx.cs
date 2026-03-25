using System;
using library;

namespace proWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ENCategory category = new ENCategory();
                ddlCategory.DataSource = category.readAll();
                ddlCategory.DataTextField = "Name";
                ddlCategory.DataValueField = "Id";
                ddlCategory.DataBind();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct producto = new ENProduct();
                producto.Code = txtCode.Text;
                producto.Name = txtName.Text;
                producto.Amount = int.Parse(txtAmount.Text);
                producto.Price = float.Parse(txtPrice.Text);
                producto.Category = int.Parse(ddlCategory.SelectedValue);
                producto.CreationDate = DateTime.Parse(txtDate.Text);

                if (producto.create())
                {
                    lblMessage.Text = "Producto creado con éxito.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "Error al crear el producto. Comprueba que el Code no exista ya.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error en los datos: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct producto = new ENProduct();
                producto.Code = txtCode.Text;
                producto.Name = txtName.Text;
                producto.Amount = int.Parse(txtAmount.Text);
                producto.Price = float.Parse(txtPrice.Text);
                producto.Category = int.Parse(ddlCategory.SelectedValue);
                producto.CreationDate = DateTime.Parse(txtDate.Text);

                if (producto.update())
                {
                    lblMessage.Text = "Producto actualizado con éxito.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "Error al actualizar. ¿Seguro que ese Code existe?";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error en los datos: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct producto = new ENProduct();
                producto.Code = txtCode.Text; 

                if (producto.delete())
                {
                    lblMessage.Text = "Producto borrado con éxito.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;

                    txtName.Text = "";
                    txtAmount.Text = "";
                    txtPrice.Text = "";
                    txtDate.Text = "";
                }
                else
                {
                    lblMessage.Text = "Error al borrar. Comprueba que el Code existe.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct producto = new ENProduct();
                producto.Code = txtCode.Text;

                if (producto.read())
                {
                    txtName.Text = producto.Name;
                    txtAmount.Text = producto.Amount.ToString();
                    txtPrice.Text = producto.Price.ToString();
                    ddlCategory.SelectedValue = producto.Category.ToString();
                    txtDate.Text = producto.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");

                    lblMessage.Text = "Producto leído con éxito.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "Error al leer. No se ha encontrado el producto.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }

        protected void btnReadFirst_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct producto = new ENProduct();
                if (producto.readFirst())
                {
                    txtCode.Text = producto.Code;
                    txtName.Text = producto.Name;
                    txtAmount.Text = producto.Amount.ToString();
                    txtPrice.Text = producto.Price.ToString();
                    ddlCategory.SelectedValue = producto.Category.ToString();
                    txtDate.Text = producto.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");

                    lblMessage.Text = "Primer producto leído con éxito.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "La base de datos está vacía.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }

        protected void btnReadNext_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct producto = new ENProduct();
                producto.Code = txtCode.Text;

                if (producto.readNext())
                {
                    txtCode.Text = producto.Code;
                    txtName.Text = producto.Name;
                    txtAmount.Text = producto.Amount.ToString();
                    txtPrice.Text = producto.Price.ToString();
                    ddlCategory.SelectedValue = producto.Category.ToString();
                    txtDate.Text = producto.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");

                    lblMessage.Text = "Siguiente producto leído con éxito.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "No hay productos posteriores.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }

        protected void btnReadPrev_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct producto = new ENProduct();
                producto.Code = txtCode.Text;

                if (producto.readPrev())
                {
                    txtCode.Text = producto.Code;
                    txtName.Text = producto.Name;
                    txtAmount.Text = producto.Amount.ToString();
                    txtPrice.Text = producto.Price.ToString();
                    ddlCategory.SelectedValue = producto.Category.ToString();
                    txtDate.Text = producto.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");

                    lblMessage.Text = "Producto anterior leído con éxito.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "No hay productos anteriores.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }
    }
}
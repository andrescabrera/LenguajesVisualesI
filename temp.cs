 if (dataGridViewEmpleados.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dataGridViewEmpleados.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridViewEmpleados.Rows[selectedRowIndex];
                Empleado empleadoSeleccionado = (Empleado)selectedRow.Tag;
                
                if (empleadoSeleccionado.GetType() == typeof(Operario))
                {
                    EditVendedor form = new EditVendedor();
                    form.SetVendedor(vendedor);
                    if (DialogResult.OK == form.ShowDialog(this))
                    {
                        Vendedor vendedor = form.GetVendedor();
                        ServicioVendedor.GetInstancia().Modificar(vendedor);
                        AgregarEmpleadoAGrilla(vendedor);
                    }
                }
            }
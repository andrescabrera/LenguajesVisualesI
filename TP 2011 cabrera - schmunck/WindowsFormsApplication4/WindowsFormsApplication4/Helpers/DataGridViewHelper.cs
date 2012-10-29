using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ControlAsistencia.Clases;

namespace ControlAsistencia.Helpers
{
    public class DataGridViewHelper
    {
        public DataGridView Grid { get; set; }
        public ContextMenu ContextMenu { get; set; }

        #region Ordenamiento de filas

        /// <summary>
        /// Agrega implementacion de SortCompare a la grilla para que las columnas se ordenen según el tipo de datos que tienen
        /// </summary>
        public void AddSortCompareHandler()
        {
            // suscripción al evento SortCompare
            Grid.SortCompare += new DataGridViewSortCompareEventHandler(dgrid_SortCompare);
        }

        /// <summary>
        /// manejador del evento SortCompare de la grilla
        /// </summary>
        /// <param name="sender">Objeto donde se generó el evento --> la grilla</param>
        /// <param name="e">Argumento del evento que contiene información sobre las filas y columnas que se comparan</param>
        private void dgrid_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            // si la columna es de tipo int, entonces realiza el ordenamiento de números enteros
            if (e.Column.ValueType == typeof(int))
            {
                // obtiene el valor entero de cada celda
                int value1 = int.Parse(e.CellValue1.ToString());
                int value2 = int.Parse(e.CellValue2.ToString());

                // compara dichos valores usando el método CompareTo de la clase int. La clase int implemente IComparable<int>
                e.SortResult = value1.CompareTo(value2);

                // indica que se realizó el manejo del evento
                e.Handled = true;
            }
            // si la columna es de tipo decimal, entonces realiza el ordenamiento de números decimales
            else if (e.Column.ValueType == typeof(decimal))
            {
                // obtiene el valor decimal de cada celda
                decimal value1 = decimal.Parse(e.CellValue1.ToString());
                decimal value2 = decimal.Parse(e.CellValue2.ToString());

                // compara dichos valores usando el método CompareTo de la clase decimal. La clase decimal implemente IComparable<decimal>
                e.SortResult = value1.CompareTo(value2);

                // indica que se realizó el manejo del evento
                e.Handled = true;
            }
            // si la columna es de tipo DateTime, entonces realiza el ordenamiento de fechas
            else if (e.Column.ValueType == typeof(DateTime))
            {
                // obtiene el valor fecha de cada celda
                DateTime value1 = DateTime.Parse(e.CellValue1.ToString());
                DateTime value2 = DateTime.Parse(e.CellValue2.ToString());

                // compara dichos valores usando el método CompareTo de la clase DateTime. La clase DateTime implemente IComparable<DateTime>
                e.SortResult = value1.CompareTo(value2);

                // indica que se realizó el manejo del evento
                e.Handled = true;
            }
        }

        #endregion

        #region Menu contextual

        public void AddContextMenuHandler()
        {
            Grid.CellMouseClick += new DataGridViewCellMouseEventHandler(dgrid_CellMouseClick);
        }

        /// <summary>
        /// manejador del evento CellMouseClick de la grilla
        /// </summary>
        /// <param name="sender">Objeto donde se generó el evento --> la grilla</param>
        /// <param name="e">Argumento del evento que contiene información el click del mouse</param>
        private void dgrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // si se presionó el botón derecho del mouse, entonces muestra el menú contextual
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // muestra el menú contextual sobre la grilla, en la posición donde se hizo el click del mouse
                ContextMenu.Show(Grid, Grid.PointToClient(Cursor.Position));
            }
        }

        #endregion
    }
}

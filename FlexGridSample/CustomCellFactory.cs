using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Util;

using Com.GrapeCity.Xuni.FlexGrid;

namespace FlexGridSample
{
    public class CustomCellFactory : GridCellFactory
    {
        public CustomCellFactory(FlexGrid flexGrid) : base(flexGrid)
        {
            
        }

        public override void CreateCellContent(GridPanel gridPanel, FlexGridCanvasRenderEngine renderEngine, GridCellRange cellRange, Rect bounds)
	    {
            if(gridPanel.CellType == GridCellType.Cell)
            {
                GridColumn column = gridPanel.Columns.Get(cellRange.Col).JavaCast<GridColumn>();

                if(column != null && column.Name == "Money")
                {
                    GridRow row = (GridRow)gridPanel.Rows.Get(cellRange.Row).JavaCast<GridRow>();

                    Customer _customer = (Customer) row.DataItem;

                    if(_customer.Money >= 80)
                    {
                        renderEngine.SetFillColor(Color.Green);
                    }
                    else
                    {
                        renderEngine.SetFillColor(Color.Blue);
                    }
                }
            }

            base.CreateCellContent(gridPanel, renderEngine, cellRange, bounds);
        }

        public override View CreateCellEditor(GridPanel gridPanel, GridCellRange cellRange, Rect bounds)
	    {
            if (gridPanel.CellType == GridCellType.Cell)
            {
                GridColumn column = gridPanel.Columns.Get(cellRange.Col).JavaCast<GridColumn>();

                if (column != null && column.Name == "Hired")
                {
                    GridRow row = (GridRow)gridPanel.Rows.Get(cellRange.Row).JavaCast<GridRow>();

                    Customer customer = (Customer)row.DataItem;

                    Dialog dialog = new DatePickerDialog(FlexGrid.Context, OnDateSet, customer.Hired.Year, customer.Hired.Month - 1, customer.Hired.Day);

                    dialog.Show();

                    return null;
                }
            }

            return base.CreateCellEditor(gridPanel, cellRange, bounds);
        }

        void OnDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            GridCellRange editRange = base.FlexGrid.EditRange;

            GridRow row = (GridRow)base.FlexGrid.Rows.Get(editRange.Row).JavaCast<GridRow>();

            Customer customer = (Customer)row.DataItem;

            customer.Hired = e.Date;

            FlexGrid.FinishEditing(false);
        }
    }
}
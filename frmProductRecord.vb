Imports System.Data.SqlClient

Imports System.IO

Public Class frmProductRecord

    Public Sub Getdata()
        Try
            If lblSet.Text = "Manufactured" Then
                GetBuildProduct()
            Else
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("Select PID, RTRIM(ProductCode),RTRIM(Productname), SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName), RTRIM(Description), CostPrice,SellingPrice, Discount, VAT, ReorderPoint,OpeningStock from Category,SubCategory,Product where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID order by PID", con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12))
                End While
            End If
            
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub


    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then

                If lblSet.Text = "Product Entry" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    frmProduct.Show()
                    Me.Hide()
                    frmProduct.txtID.Text = dr.Cells(0).Value.ToString()
                    frmProduct.txtProductCode.Text = dr.Cells(1).Value.ToString()
                    frmProduct.txtProductName.Text = dr.Cells(2).Value.ToString()
                    frmProduct.txtSubCategoryID.Text = dr.Cells(3).Value.ToString()
                    frmProduct.cmbCategory.Text = dr.Cells(4).Value.ToString()
                    frmProduct.cmbSubCategory.Text = dr.Cells(5).Value.ToString()
                    frmProduct.txtFeatures.Text = dr.Cells(6).Value.ToString()
                    frmProduct.txtCostPrice.Text = dr.Cells(7).Value.ToString()
                    frmProduct.txtSellingPrice.Text = dr.Cells(8).Value.ToString()
                    frmProduct.txtDiscount.Text = dr.Cells(9).Value.ToString()
                    frmProduct.txtVAT.Text = dr.Cells(10).Value.ToString()
                    frmProduct.txtReorderPoint.Text = dr.Cells(11).Value.ToString()
                    frmProduct.txtOpeningStock.Text = dr.Cells(12).Value.ToString()
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = New SqlCommand("SELECT Photo from Product,Product_Join where Product.PID=Product_Join.ProductID and Product.PID=@d1", con)
                    cmd.Parameters.AddWithValue("@d1", dr.Cells(0).Value.ToString())
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    frmProduct.dgw.Rows.Clear()
                    While (rdr.Read() = True)
                        Dim img4 As Image
                        Dim data As Byte() = DirectCast(rdr(0), Byte())
                        Dim ms As New MemoryStream(data)
                        img4 = Image.FromStream(ms)
                        frmProduct.dgw.Rows.Add(img4)
                    End While
                    con.Close()
                    frmProduct.btnUpdate.Enabled = True
                    frmProduct.btnDelete.Enabled = True
                    frmProduct.btnSave.Enabled = False
                    frmProduct.txtOpeningStock.Enabled = False
                    frmProduct.txtOpeningStock.ReadOnly = True
                    lblSet.Text = ""
                End If
            End If
            If lblSet.Text = "Quotation" Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                frmQuotation.Show()
                Me.Hide()
                frmQuotation.txtProductID.Text = dr.Cells(0).Value.ToString()
                frmQuotation.txtProductCode.Text = dr.Cells(1).Value.ToString()
                frmQuotation.txtProductName.Text = dr.Cells(2).Value.ToString()
                frmQuotation.txtSellingPrice.Text = dr.Cells(8).Value.ToString()
                frmQuotation.txtDiscountPer.Text = dr.Cells(9).Value.ToString()
                frmQuotation.txtVAT.Text = dr.Cells(10).Value.ToString()
                lblSet.Text = ""
            End If

            If lblSet.Text = "Stock" Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                frmPurchase.Show()
                Me.Hide()
                frmPurchase.txtProductID.Text = dr.Cells(0).Value.ToString()
                frmPurchase.txtProductCode.Text = dr.Cells(1).Value.ToString()
                frmPurchase.txtProductName.Text = dr.Cells(2).Value.ToString()
                frmPurchase.txtPricePerQty.Text = dr.Cells(7).Value.ToString()
                frmPurchase.txtQty.Focus()
                lblSet.Text = ""
            End If

            If lblSet.Text = "OurProductStock" Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                frmOurCreation.Show()
                Me.Hide()
                frmOurCreation.txtProductID.Text = dr.Cells(0).Value.ToString()
                frmOurCreation.txtProductCode.Text = dr.Cells(1).Value.ToString()
                frmOurCreation.txtProductName.Text = dr.Cells(2).Value.ToString()
                frmOurCreation.txtPricePerQty.Text = dr.Cells(7).Value.ToString()
                frmOurCreation.txtQty.Focus()
                lblSet.Text = ""
            End If

            If lblSet.Text = "Billing" Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                frmBilling.Show()
                Me.Hide()
                frmBilling.txtProductID.Text = dr.Cells(0).Value.ToString()
                frmBilling.txtProductCode.Text = dr.Cells(1).Value.ToString()
                frmBilling.txtProductName.Text = dr.Cells(2).Value.ToString()
                frmBilling.txtSellingPrice.Text = dr.Cells(8).Value.ToString()
                frmBilling.txtDiscountPer.Text = dr.Cells(9).Value.ToString()
                frmBilling.txtVAT.Text = dr.Cells(10).Value.ToString()
                lblSet.Text = ""
            End If
            If lblSet.Text = "Manufactured" Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                frmBPBilling.Show()
                Me.Hide()
                frmBPBilling.txtProductID.Text = dr.Cells(0).Value.ToString()
                frmBPBilling.txtProductCode.Text = dr.Cells(1).Value.ToString()
                frmBPBilling.txtProductName.Text = dr.Cells(2).Value.ToString()
                frmBPBilling.txtSellingPrice.Text = dr.Cells(8).Value.ToString()
                frmBPBilling.txtDiscountPer.Text = dr.Cells(9).Value.ToString()
                frmBPBilling.txtVAT.Text = dr.Cells(10).Value.ToString()
                lblSet.Text = ""
            End If
            If lblSet.Text = "Billing1" Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                frmBilling1.Show()
                Me.Hide()
                frmBilling1.txtProductID.Text = dr.Cells(0).Value.ToString()
                frmBilling1.txtProductCode.Text = dr.Cells(1).Value.ToString()
                frmBilling1.txtProductName.Text = dr.Cells(2).Value.ToString()
                frmBilling1.txtSellingPrice.Text = dr.Cells(8).Value.ToString()
                frmBilling1.txtDiscountPer.Text = dr.Cells(9).Value.ToString()
                frmBilling1.txtVAT.Text = dr.Cells(10).Value.ToString()
                lblSet.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgw_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub
    Sub Reset()
        txtProductName.Text = ""
        txtCategory.Text = ""
        txtSubCategory.Text = ""
        Getdata()
    End Sub
    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    Private Sub txtProductName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtProductName.TextChanged
        Try
            If lblSet.Text = "Manufactured" Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("SELECT OP.OPID,RTRIM(OP.OProductCode),RTRIM(OP.OProductName),OP.SubCategoryID, RTRIM(C.CategoryName),RTRIM(SC.SubCategoryName),RTRIM(OP.Description),OP.CostPrice,OP.SellingPrice,OP.Discount,OP.VAT FROM OurProduct OP, Category C, SubCategory SC	WHERE C.CategoryName = SC.Category AND OP.SubCategoryID = SC.ID AND OP.OProductName like '%" & txtProductName.Text & "%'	ORDER BY OP.OPID", con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                dgw.Columns.Clear()
                dgw.Columns.Add("Col1", "ID")
                dgw.Columns.Add("Col2", "Product Code")
                dgw.Columns.Add("Col3", "Product Name")
                dgw.Columns.Add("Col4", "Sub Category ID")
                dgw.Columns.Add("Col5", "Category Name")
                dgw.Columns.Add("Col6", "Sub Category Name")
                dgw.Columns.Add("Col7", "Description")
                dgw.Columns.Add("Col8", "Idle Cost")
                dgw.Columns.Add("Col9", "Selling Price")
                dgw.Columns.Add("Col10", "Discount")
                dgw.Columns.Add("Col11", "Vat")
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10))
                End While
                con.Close()
            Else
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("Select PID, RTRIM(ProductCode),RTRIM(Productname), SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName), RTRIM(Description), CostPrice,SellingPrice, Discount, VAT, ReorderPoint,OpeningStock from Category,SubCategory,Product where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and ProductName like '%" & txtProductName.Text & "%' order by PID", con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12))
                End While
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCategory_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCategory.TextChanged
        Try
            If lblSet.Text = "Manufactured" Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("SELECT OP.OPID,RTRIM(OP.OProductCode),RTRIM(OP.OProductName),OP.SubCategoryID, RTRIM(C.CategoryName),RTRIM(SC.SubCategoryName),RTRIM(OP.Description),OP.CostPrice,OP.SellingPrice,OP.Discount,OP.VAT FROM OurProduct OP, Category C, SubCategory SC	WHERE C.CategoryName = SC.Category AND OP.SubCategoryID = SC.ID AND C.CategoryName like '%" & txtCategory.Text & "%'	ORDER BY OP.OPID", con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                dgw.Columns.Clear()
                dgw.Columns.Add("Col1", "ID")
                dgw.Columns.Add("Col2", "Product Code")
                dgw.Columns.Add("Col3", "Product Name")
                dgw.Columns.Add("Col4", "Sub Category ID")
                dgw.Columns.Add("Col5", "Category Name")
                dgw.Columns.Add("Col6", "Sub Category Name")
                dgw.Columns.Add("Col7", "Description")
                dgw.Columns.Add("Col8", "Idle Cost")
                dgw.Columns.Add("Col9", "Selling Price")
                dgw.Columns.Add("Col10", "Discount")
                dgw.Columns.Add("Col11", "Vat")
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10))
                End While
                con.Close()
            Else
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("Select PID, RTRIM(ProductCode),RTRIM(Productname), SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName), RTRIM(Description), CostPrice,SellingPrice, Discount, VAT, ReorderPoint,OpeningStock from Category,SubCategory,Product where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and CategoryName like '%" & txtCategory.Text & "%' order by PID", con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12))
                End While
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSubCategory_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSubCategory.TextChanged
        Try
            If lblSet.Text = "Manufactured" Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("SELECT OP.OPID,RTRIM(OP.OProductCode),RTRIM(OP.OProductName),OP.SubCategoryID, RTRIM(C.CategoryName),RTRIM(SC.SubCategoryName),RTRIM(OP.Description),OP.CostPrice,OP.SellingPrice,OP.Discount,OP.VAT FROM OurProduct OP, Category C, SubCategory SC	WHERE C.CategoryName = SC.Category AND OP.SubCategoryID = SC.ID AND SC.SubCategoryName like '%" & txtSubCategory.Text & "%' ORDER BY OP.OPID", con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                dgw.Columns.Clear()
                dgw.Columns.Add("Col1", "ID")
                dgw.Columns.Add("Col2", "Product Code")
                dgw.Columns.Add("Col3", "Product Name")
                dgw.Columns.Add("Col4", "Sub Category ID")
                dgw.Columns.Add("Col5", "Category Name")
                dgw.Columns.Add("Col6", "Sub Category Name")
                dgw.Columns.Add("Col7", "Description")
                dgw.Columns.Add("Col8", "Idle Cost")
                dgw.Columns.Add("Col9", "Selling Price")
                dgw.Columns.Add("Col10", "Discount")
                dgw.Columns.Add("Col11", "Vat")
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10))
                End While
                con.Close()
            Else
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("Select PID, RTRIM(ProductCode),RTRIM(Productname), SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName), RTRIM(Description), CostPrice,SellingPrice, Discount, VAT, ReorderPoint,OpeningStock from Category,SubCategory,Product where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and SubCategoryName like '%" & txtSubCategory.Text & "%' order by PID", con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12))
                End While
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub GetBuildProduct()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT OP.OPID,RTRIM(OP.OProductCode),RTRIM(OP.OProductName),OP.SubCategoryID, RTRIM(C.CategoryName),RTRIM(SC.SubCategoryName),RTRIM(OP.Description),OP.CostPrice,OP.SellingPrice,OP.Discount,OP.VAT FROM OurProduct OP, Category C, SubCategory SC	WHERE C.CategoryName = SC.Category AND OP.SubCategoryID = SC.ID	ORDER BY OP.OPID", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            dgw.Columns.Clear()
            dgw.Columns.Add("Col1", "ID")
            dgw.Columns.Add("Col2", "Product Code")
            dgw.Columns.Add("Col3", "Product Name")
            dgw.Columns.Add("Col4", "Sub Category ID")
            dgw.Columns.Add("Col5", "Category Name")
            dgw.Columns.Add("Col6", "Sub Category Name")
            dgw.Columns.Add("Col7", "Description")
            dgw.Columns.Add("Col8", "Idle Cost")
            dgw.Columns.Add("Col9", "Selling Price")
            dgw.Columns.Add("Col10", "Discount")
            dgw.Columns.Add("Col11", "Vat")
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgw_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw.CellContentClick

    End Sub
End Class

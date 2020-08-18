Imports System.Data.SqlClient
Imports System.IO
Public Class frmBuildProductRecord
    Sub Reset()
        txtProductName.Text = ""
        txtCategory.Text = ""
        txtSubCategory.Text = ""
        Getdata()
    End Sub
    Public Sub Getdata()
        Try
            If lblSet.Text = "Build Product GetData" Then
                GetBuildData()
            Else
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("SELECT OPID,RTRIM(OProductCode),RTRIM(OProductName),SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName),RTRIM(Description),CostPrice,SellingPrice,Discount,VAT,LabourCharges,ElectricityCharges,OtherCharges	FROM Category, SubCategory, OurProduct WHERE Category.CategoryName = SubCategory.Category AND OurProduct.SubCategoryID = SubCategory.ID	ORDER BY OPID", con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
                End While
            End If
            
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmBuildProductRecord_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Getdata()
    End Sub
    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                If lblSet.Text = "Build Product Entry" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    frmOurCreation.Show()
                    Me.Hide()
                    frmOurCreation.txtID.Text = dr.Cells(0).Value.ToString()
                    frmOurCreation.txtOProductCode.Text = dr.Cells(1).Value.ToString()
                    frmOurCreation.txtOProductName.Text = dr.Cells(2).Value.ToString()
                    frmOurCreation.txtSubCategoryID.Text = dr.Cells(3).Value.ToString()
                    frmOurCreation.cmbCategory.Text = dr.Cells(4).Value.ToString()
                    frmOurCreation.cmbSubCategory.Text = dr.Cells(5).Value.ToString()
                    frmOurCreation.txtfeatures.Text = dr.Cells(6).Value.ToString()
                    frmOurCreation.txtCostOfPrice.Text = dr.Cells(7).Value.ToString()
                    frmOurCreation.txtSellingPrice.Text = dr.Cells(8).Value.ToString()
                    frmOurCreation.txtDiscPer.Text = dr.Cells(9).Value.ToString()
                    frmOurCreation.txtVat.Text = dr.Cells(10).Value.ToString()
                    frmOurCreation.txtLabourCharges.Text = dr.Cells(11).Value.ToString()
                    frmOurCreation.txtElectricityCharges.Text = dr.Cells(12).Value.ToString()
                    frmOurCreation.txtOtherCharges.Text = dr.Cells(13).Value.ToString()
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = New SqlCommand("SELECT Photo FROM OurProduct WHERE OurProduct.OPID = @d1", con)
                    cmd.Parameters.AddWithValue("@d1", dr.Cells(0).Value.ToString())
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    frmOurCreation.dgw.Rows.Clear()
                    While (rdr.Read() = True)
                        Dim img4 As Image
                        Dim data As Byte() = DirectCast(rdr(0), Byte())
                        Dim ms As New MemoryStream(data)
                        img4 = Image.FromStream(ms)
                        frmOurCreation.dgw.Rows.Add(img4)
                    End While
                    con.Close()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql As String = "SELECT P.PID,RTRIM(P.ProductCode),RTRIM(P.ProductName),SOP.Price,SOP.Qty,SOP.TotalAmount FROM OurProduct OP,Product P, Sub_OProduct SOP WHERE P.PID = SOP.ProductID AND OP.OPID = SOP.OurproductId AND OP.OPID =" & dr.Cells(0).Value & ""
                    cmd = New SqlCommand(sql, con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    frmOurCreation.DataGridView1.Rows.Clear()
                    While (rdr.Read() = True)
                        frmOurCreation.DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
                    End While
                    con.Close()
                    frmOurCreation.btnUpdate.Enabled = True
                    frmOurCreation.btnDelete.Enabled = True
                    frmOurCreation.btnSave.Enabled = False
                    lblSet.Text = ""
                    
                End If
                If lblSet.Text = "OurProductStockAdd" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    frmBuildProducts.Show()
                    Me.Hide()
                    frmBuildProducts.txtProductID.Text = dr.Cells(0).Value.ToString()
                    frmBuildProducts.txtProductCode.Text = dr.Cells(1).Value.ToString()
                    frmBuildProducts.txtProductName.Text = dr.Cells(2).Value.ToString()
                    frmBuildProducts.txtPricePerQty.Text = dr.Cells(7).Value.ToString()
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = New SqlCommand("SELECT SP.OurproductId,SP.ProductID,SP.Price,SP.Qty,SP.TotalAmount FROM Sub_OProduct SP,OurProduct OP WHERE OP.OPID = SP.OurproductId AND OP.OPID = @d1", con)
                    cmd.Parameters.AddWithValue("@d1", dr.Cells(0).Value.ToString())
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    frmBuildProducts.dgwRawstk1.Rows.Clear()
                    While (rdr.Read() = True)
                        frmBuildProducts.dgwRawstk1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4))
                    End While
                    con.Close()
                    lblSet.Text = ""
                End If
                If lblSet.Text = "Build Product GetData" Then
                    'GetBuildData()
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    frmBuildProducts.Show()
                    Me.Hide()
                    frmBuildProducts.txtBuildId.Text = dr.Cells(0).Value.ToString()
                    frmBuildProducts.txtBuildNo.Text = dr.Cells(1).Value.ToString()
                    frmBuildProducts.dtpDate.Text = dr.Cells(2).Value.ToString()
                    frmBuildProducts.txtProductID.Text = dr.Cells(3).Value.ToString()
                    frmBuildProducts.txtPricePerQty.Text = dr.Cells(4).Value.ToString()
                    frmBuildProducts.txtQty.Text = dr.Cells(5).Value.ToString()
                    frmBuildProducts.txtTotalAmount.Text = dr.Cells(6).Value.ToString()
                    frmBuildProducts.txtProductCode.Text = dr.Cells(9).Value.ToString()
                    frmBuildProducts.txtProductName.Text = dr.Cells(10).Value.ToString()
                    frmBuildProducts.txtRemarks.Text = dr.Cells(7).Value.ToString()
                    con.Close()
                    lblSet.Text = ""
                    frmBuildProducts.btnDelete.Enabled = True
                    frmBuildProducts.btnSave.Enabled = False
                End If
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

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub txtProductName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT OPID,RTRIM(OProductCode),RTRIM(OProductName),SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName),RTRIM(Description),CostPrice,SellingPrice,Discount,VAT,LabourCharges,ElectricityCharges,OtherCharges	FROM Category, SubCategory, OurProduct WHERE Category.CategoryName = SubCategory.Category AND OurProduct.SubCategoryID = SubCategory.ID	and OProductName like '%" & txtProductName.Text & "%' ORDER BY OPID", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtCategory_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCategory.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT OPID,RTRIM(OProductCode),RTRIM(OProductName),SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName),RTRIM(Description),CostPrice,SellingPrice,Discount,VAT,LabourCharges,ElectricityCharges,OtherCharges	FROM Category, SubCategory, OurProduct WHERE Category.CategoryName = SubCategory.Category AND OurProduct.SubCategoryID = SubCategory.ID	and CategoryName like '%" & txtCategory.Text & "%' ORDER BY OPID", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtSubCategory_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubCategory.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT OPID,RTRIM(OProductCode),RTRIM(OProductName),SubCategoryID,RTRIM(CategoryName),RTRIM(SubCategoryName),RTRIM(Description),CostPrice,SellingPrice,Discount,VAT,LabourCharges,ElectricityCharges,OtherCharges	FROM Category, SubCategory, OurProduct WHERE Category.CategoryName = SubCategory.Category AND OurProduct.SubCategoryID = SubCategory.ID	and SubCategoryName like '%" & txtSubCategory.Text & "%' ORDER BY OPID", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub
    Private Sub GetBuildData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT BI.BUILDID,BI.BuildNo,BI.BuildDate,BI.OurProductId,BI.PricePerUnit,BI.BuildQty,BI.TotalAmount,BI.Remarks,OP.OPID,OP.OProductCode,OP.OProductName FROM BuildProductInfo BI, OurProduct OP WHERE BI.OurProductId = OP.OPID ORDER BY BI.BUILDID", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            dgw.Columns.Clear()
            dgw.Columns.Add("col1", "ID")
            dgw.Columns.Add("col2", "Build No")
            dgw.Columns.Add("col3", "Build Date")
            dgw.Columns.Add("col4", "OP ID")
            dgw.Columns.Add("col5", "PP Unit")
            dgw.Columns.Add("col6", "Quantity")
            dgw.Columns.Add("col7", "Total Amount")
            dgw.Columns.Add("col8", "Remarks")
            dgw.Columns.Add("col9", "Our Product ID")
            dgw.Columns.Add("col10", "Product Code")
            dgw.Columns.Add("col11", "Product Name")
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
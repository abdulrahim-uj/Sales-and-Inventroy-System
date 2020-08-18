Imports System.Data.SqlClient
Imports System.IO

Public Class frmOurCreation
    Dim str As String
    Dim num1, num2, num3, num4, num5, num6, num7, num8, num9, num10, num11 As Decimal
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub frmOurCreation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillCategory()
    End Sub
    Sub fillCategory()
        Try
            con = New SqlConnection(cs)
            con.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(CategoryName) FROM Category", con)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbCategory.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbCategory.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategory.SelectedIndexChanged
        Try
            cmbSubCategory.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT distinct RTRIM(SubCategoryName) FROM SubCategory,Category where SubCategory.Category=Category.CategoryName and CategoryName=@d1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbCategory.Text)
            rdr = cmd.ExecuteReader()
            cmbSubCategory.Items.Clear()
            While rdr.Read
                cmbSubCategory.Items.Add(rdr(0))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Fill()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT ID from SubCategory where Category=@d1 and SubCategoryName=@d2"
            cmd.Parameters.AddWithValue("@d1", cmbCategory.Text)
            cmd.Parameters.AddWithValue("@d2", cmbSubCategory.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtSubCategoryID.Text = rdr.GetValue(0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub Reset()
        txtOProductName.Text = ""
        txtDiscPer.Text = "0.00"
        txtVat.Text = "0.00"
        txtSubTotal.Text = "0.00"
        txtOtherCharges.Text = "0.00"
        txtLabourCharges.Text = "0.00"
        txtElectricityCharges.Text = "0.00"
        txtOpeningStock.Text = 0
        txtSellingPrice.Text = ""
        txtCostOfPrice.ReadOnly = True
        btnSave.Enabled = True
        btnDelete.Enabled = False
        DataGridView1.Enabled = True
        btnAdd.Enabled = True
        pnlCalc.Enabled = True
        Picture.Image = My.Resources._12
        dgw.Rows.Clear()
        DataGridView1.Rows.Clear()
        Clear()
        cmbCategory.SelectedIndex = -1
        cmbSubCategory.SelectedIndex = -1
        cmbSubCategory.Enabled = False
        txtOProductCode.Focus()
        auto()
    End Sub
    Sub auto()
        Try
            txtID.Text = GenerateID()
            txtOProductCode.Text = "OP-" + GenerateID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Function GenerateID() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 OPID FROM OurProduct ORDER BY OPID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("OPID")
            End If
            rdr.Close()
            ' Increase the ID by 1
            value += 1
            ' Because incrementing a string with an integer removes 0's
            ' we need to replace them. If necessary.
            If value <= 9 Then 'Value is between 0 and 10
                value = "000" & value
            ElseIf value <= 99 Then 'Value is between 9 and 100
                value = "00" & value
            ElseIf value <= 999 Then 'Value is between 999 and 1000
                value = "0" & value
            End If
        Catch ex As Exception
            ' If an error occurs, check the connection state and close it if necessary.
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            value = "0000"
        End Try
        Return value
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmProductRecord.lblSet.Text = "OurProductStock"
        frmProductRecord.Reset()
        frmProductRecord.ShowDialog()
    End Sub
    Private Sub txtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.TextChanged
        Dim i As Double = 0
        i = CDbl(Val(txtQty.Text) * Val(txtPricePerQty.Text))
        i = Math.Round(i, 2)
        txtTotalAmount.Text = i
    End Sub
    Private Sub txtPricePerQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPricePerQty.TextChanged
        Dim i As Double = 0
        i = CDbl(Val(txtQty.Text) * Val(txtPricePerQty.Text))
        i = Math.Round(i, 2)
        txtTotalAmount.Text = i
    End Sub
    Private Sub txtQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtPricePerQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPricePerQty.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtPricePerQty.Text
            Dim selectionStart = Me.txtPricePerQty.SelectionStart
            Dim selectionLength = Me.txtPricePerQty.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If txtProductCode.Text = "" Then
                MessageBox.Show("Please retrieve product code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProductCode.Focus()
                Exit Sub
            End If
            If txtQty.Text = "" Then
                MessageBox.Show("Please enter quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If
            If txtQty.Text = 0 Then
                MessageBox.Show("Quantity can not be zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If
            If txtPricePerQty.Text = "" Then
                MessageBox.Show("Please enter price per qty.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPricePerQty.Focus()
                Exit Sub
            End If
            If DataGridView1.Rows.Count = 0 Then
                DataGridView1.Rows.Add(txtProductID.Text, txtProductCode.Text, txtProductName.Text, txtPricePerQty.Text, txtQty.Text, txtTotalAmount.Text)
                Dim k As Double = 0
                k = SubTotal()
                k = Math.Round(k, 2)
                txtSubTotal.Text = k
                Clear()
                Exit Sub
            End If
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                If r.Cells(1).Value = txtProductCode.Text Then
                    r.Cells(0).Value = txtProductID.Text
                    r.Cells(1).Value = txtProductCode.Text
                    r.Cells(2).Value = txtProductName.Text
                    r.Cells(4).Value = Val(r.Cells(4).Value) + Val(txtQty.Text)
                    r.Cells(3).Value = txtPricePerQty.Text
                    r.Cells(5).Value = Val(r.Cells(5).Value) + Val(txtTotalAmount.Text)
                    Dim i As Double = 0
                    i = SubTotal()
                    i = Math.Round(i, 2)
                    txtSubTotal.Text = i
                    Clear()
                    Exit Sub
                End If
            Next
            DataGridView1.Rows.Add(txtProductID.Text, txtProductCode.Text, txtProductName.Text, txtPricePerQty.Text, txtQty.Text, txtTotalAmount.Text)
            Dim j As Double = 0
            j = SubTotal()
            j = Math.Round(j, 2)
            txtSubTotal.Text = j
            Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function SubTotal() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + r.Cells(5).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Sub Clear()
        txtProductCode.Text = ""
        txtProductName.Text = ""
        txtQty.Text = ""
        txtPricePerQty.Text = ""
        txtTotalAmount.Text = ""
    End Sub
    Private Sub DataGridView1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        If DataGridView1.Rows.Count > 0 Then
            btnRemove.Enabled = True
        End If

        'r.Cells(0).Value = txtProductID.Text
        'r.Cells(1).Value = txtProductCode.Text
        'r.Cells(2).Value = txtProductName.Text
        'r.Cells(4).Value = Val(r.Cells(4).Value) + Val(txtQty.Text)
        'r.Cells(3).Value = txtPricePerQty.Text
        'r.Cells(5).Value = Val(r.Cells(5).Value) + Val(txtTotalAmount.Text)
        Dim row As DataGridViewRow = Me.DataGridView1.SelectedRows.Item(0)
        Me.txtProductCode.Text = (row.Cells.Item(1).Value)
        Me.txtProductID.Text = (row.Cells.Item(0).Value)
        Me.txtProductName.Text = (row.Cells.Item(2).Value)
        Me.txtPricePerQty.Text = (row.Cells.Item(3).Value)
        Me.txtQty.Text = (row.Cells.Item(4).Value)
        Me.txtTotalAmount.Text = (row.Cells.Item(5).Value)
        btnAdd.Enabled = False
        btnListUpdate.Enabled = True
    End Sub

    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Try
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
            Dim k As Double = 0
            k = SubTotal()
            k = Math.Round(k, 2)
            txtSubTotal.Text = k
            Compute()
            btnRemove.Enabled = False
            Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Compute()
        'num6 = (Val(txtSubTotal.Text) * Val(txtDiscPer.Text)) / 100
        'num6 = Math.Round(num6, 2)
        'txtDisc.Text = num6
        'num7 = Val(txtSubTotal.Text) - num6
        'num1 = num7 + Val(txtFreightCharges.Text) + Val(txtOtherCharges.Text) + Val(txtPreviousDue.Text)
        'num1 = Math.Round(num1, 2)
        'txtTotal.Text = num1
        'num2 = Math.Round(num1, 1)
        'num3 = num2 - num1
        'num3 = Math.Round(num3, 2)
        'txtRoundOff.Text = num3
        'num4 = Val(txtTotal.Text) + Val(txtRoundOff.Text)
        'num4 = Math.Round(num4, 2)
        'txtGrandTotal.Text = num4
        'num5 = Val(txtGrandTotal.Text) - Val(txtTotalPaid.Text)
        'num5 = Math.Round(num5, 2)
        'txtBalance.Text = num5
        
        num6 = (Val(txtSubTotal.Text) + Val(txtLabourCharges.Text) + Val(txtElectricityCharges.Text) + Val(txtOtherCharges.Text))
        num6 = Math.Round(num6, 2)
        txtCostOfPrice.Text = num6
    End Sub
    Private Sub txtSubTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubTotal.TextChanged
        Compute()
    End Sub

    Private Sub txtLabourCharges_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLabourCharges.TextChanged
        Compute()
    End Sub

    Private Sub txtElectricityCharges_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtElectricityCharges.TextChanged
        Compute()
    End Sub

    Private Sub txtOtherCharges_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOtherCharges.TextChanged
        Compute()
    End Sub

    Private Sub btnListUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListUpdate.Click
        Try
            If txtProductCode.Text = "" Then
                MessageBox.Show("Please retrieve product code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProductCode.Focus()
                Exit Sub
            End If
            If txtQty.Text = "" Then
                MessageBox.Show("Please enter quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If
            If txtQty.Text = 0 Then
                MessageBox.Show("Quantity can not be zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If

            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
            If DataGridView1.Rows.Count = 0 Then
                DataGridView1.Rows.Add(txtProductID.Text, txtProductCode.Text, txtProductName.Text, txtPricePerQty.Text, txtQty.Text, txtTotalAmount.Text)
                Dim k As Double = 0
                k = SubTotal()
                k = Math.Round(k, 2)
                txtSubTotal.Text = k
                Clear()
                Exit Sub
            End If
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                If r.Cells(1).Value = txtProductCode.Text Then
                    r.Cells(0).Value = txtProductID.Text
                    r.Cells(1).Value = txtProductCode.Text
                    r.Cells(2).Value = txtProductName.Text
                    r.Cells(4).Value = Val(r.Cells(4).Value) + Val(txtQty.Text)
                    r.Cells(3).Value = txtPricePerQty.Text
                    r.Cells(5).Value = Val(r.Cells(5).Value) + Val(txtTotalAmount.Text)
                    Dim i As Double = 0
                    i = SubTotal()
                    i = Math.Round(i, 2)
                    txtSubTotal.Text = i
                    Clear()
                    Exit Sub
                End If
            Next
            DataGridView1.Rows.Add(txtProductID.Text, txtProductCode.Text, txtProductName.Text, txtPricePerQty.Text, txtQty.Text, txtTotalAmount.Text)
            Dim j As Double = 0
            j = SubTotal()
            j = Math.Round(j, 2)
            txtSubTotal.Text = j
            Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browse.Click
        Try
            With OpenFileDialog1
                .Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                Picture.Image = Image.FromFile(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub BRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRemove.Click
        Picture.Image = My.Resources._12
    End Sub
    Private Sub btnImageAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImageAdd.Click
        dgw.Rows.Add(Picture.Image)
    End Sub

    Private Sub btnImageRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImageRemove.Click
        Try
            For Each row As DataGridViewRow In dgw.SelectedRows
                dgw.Rows.Remove(row)
            Next
            btnRemove.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtOProductName.Text)) = 0 Then
            MessageBox.Show("Please enter Product Name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtOProductName.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbCategory.Text)) = 0 Then
            MessageBox.Show("Please select category", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCategory.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbSubCategory.Text)) = 0 Then
            MessageBox.Show("Please select sub category", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbSubCategory.Focus()
            Exit Sub
        End If

        If Len(Trim(txtCostOfPrice.Text)) = 0 Then
            MessageBox.Show("Please enter cost price", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCostOfPrice.Focus()
            Exit Sub
        End If
        
        If Len(Trim(txtSellingPrice.Text)) = 0 Then
            MessageBox.Show("Please enter selling price", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSellingPrice.Focus()
            Exit Sub
        End If
        If dgw.Rows.Count = 0 Then
            MessageBox.Show("Please add product images in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Try
            Fill()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "INSERT INTO OurProduct (OPID,OProductCode,OProductName,SubCategoryID,Description,CostPrice,SellingPrice,Discount,VAT,LabourCharges,ElectricityCharges,OtherCharges,Photo) VALUES (" & txtID.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", txtOProductCode.Text)
            cmd.Parameters.AddWithValue("@d2", txtOProductName.Text)
            cmd.Parameters.AddWithValue("@d3", Val(txtSubCategoryID.Text))
            txtfeatures.Text = "Not Available"
            cmd.Parameters.AddWithValue("@d4", txtFeatures.Text)
            cmd.Parameters.AddWithValue("@d5", Val(txtCostOfPrice.Text))
            cmd.Parameters.AddWithValue("@d6", Val(txtSellingPrice.Text))
            cmd.Parameters.AddWithValue("@d7", Val(txtDiscPer.Text))
            cmd.Parameters.AddWithValue("@d8", Val(txtVat.Text))
            cmd.Parameters.AddWithValue("@d9", Val(txtLabourCharges.Text))
            cmd.Parameters.AddWithValue("@d10", Val(txtElectricityCharges.Text))
            cmd.Parameters.AddWithValue("@d11", Val(txtOtherCharges.Text))
            For Each row As DataGridViewRow In dgw.Rows
                If Not row.IsNewRow Then
                    Dim ms As New MemoryStream()
                    Dim img As Image = row.Cells(0).Value
                    Dim bmpImage As New Bitmap(img)
                    bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Dim data As Byte() = ms.GetBuffer()
                    Dim p As New SqlParameter("@d12", SqlDbType.Image)
                    p.Value = data
                    cmd.Parameters.Add(p)
                End If
            Next
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\'
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "INSERT INTO Sub_OProduct (OurproductId,ProductID,Price,Qty,TotalAmount) VALUES (" & txtID.Text & ",@d1,@d2,@d3,@d4)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(3).Value))
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(4).Value))
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(5).Value))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            'For Each row As DataGridViewRow In DataGridView1.Rows
            '    If Not row.IsNewRow Then
            '        con = New SqlConnection(cs)
            '        con.Open()
            '        Dim ctx As String = "select ProductID from Temp_Stock where ProductID=@d1"
            '        cmd = New SqlCommand(ctx)
            '        cmd.Connection = con
            '        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
            '        rdr = cmd.ExecuteReader()
            '        If (rdr.Read()) Then

            '            con = New SqlConnection(cs)
            '            con.Open()
            '            Dim cb2 As String = "Update Temp_Stock set Qty = Qty - " & row.Cells(4).Value & " where ProductID=@d1"
            '            cmd = New SqlCommand(cb2)
            '            cmd.Connection = con
            '            cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
            '            cmd.ExecuteReader()
            '            con.Close()
            '        End If
            '    End If
            'Next
            con = New SqlConnection(cs)
            con.Open()
            Dim buildstock As String = "INSERT INTO build_Stock (OurProductID,Qty) VALUES (" & txtID.Text & ",@d1)"
            cmd = New SqlCommand(buildstock)
            cmd.Parameters.AddWithValue("@d1", txtOpeningStock.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            LogFunc(lblUser.Text, "added the new Build Product '" & txtOProductName.Text & "' having Product code '" & txtOProductCode.Text & "'")
            RefreshRecords()
            MessageBox.Show("Successfully saved", "Product Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Reset()
            auto()
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click
        Dim frm As New frmBuildProductRecord
        frm.lblSet.Text = "Build Product Entry"
        frm.Reset()
        frm.ShowDialog()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from OurProduct where OPID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb2 As String = "Update Temp_Stock set Qty = Qty + " & row.Cells(4).Value & " where ProductID=@d1"
                    cmd = New SqlCommand(cb2)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                    cmd.ExecuteReader()
                    con.Close()
                End If
            Next
            con = New SqlConnection(cs)
            con.Open()
            Dim dlsub As String = "delete from Sub_OProduct where OurproductId=@d1"
            cmd = New SqlCommand(dlsub)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim blstock As String = "delete from build_Stock where OurProductID=@d1"
            cmd = New SqlCommand(blstock)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            'If RowsAffected > 0 Then
            '    LedgerDelete(txtInvoiceNo.Text)
            '    SupplierLedgerDelete(txtInvoiceNo.Text)
            '    LogFunc(lblUser.Text, "deleted the purchase record having Invoice No. '" & txtInvoiceNo.Text & "'")
            '    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Reset()
            '    RefreshRecords()
            'Else
            '    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Reset()
            'End If
            LogFunc(lblUser.Text, "deleted the Build Product record having Product Code '" & txtOProductCode.Text & "' and Product Name '" & txtOProductName.Text & "' ")
            MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Reset()
            RefreshRecords()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
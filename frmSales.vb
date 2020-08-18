Imports System.Data.SqlClient

Public Class frmSales
    Dim st2 As String

    Sub Reset()
        txtCID.Text = ""
        txtInvoiceNo.Text = ""
        dtpInvoiceDate.Text = Today
        txtSalesmanId.Text = ""
        txtSalesmanName.Text = ""
        txtCustomerID.Text = ""
        txtCustomerName.Text = ""
        txtContactNo.Text = ""

        txtProductCode.Text = ""
        txtProductName.Text = ""
        txtAmount.Text = ""
        txtQty.Text = ""
        txtSellingPrice.Text = ""
        txtDiscountAmount.Text = ""
        txtDiscountPer.Text = ""
        txtTotalAmount.Text = ""
        txtTotalQty.Text = ""
        txtVAT.Text = ""
        txtVATAmount.Text = ""

        txtTransactionNo.Text = ""
        txtPayment.Text = ""
        dtpPaymentDate.Text = Today

        txtRemarks.Text = ""

        txtGrandTotal.Text = ""
        txtTotalPayment.Text = ""
        txtPaymentDue.Text = ""

        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnSave.Enabled = True
        btnRemove.Enabled = False
        btnAdd.Enabled = True
        btnPrint.Enabled = False
        btnDeleteNew.Enabled = False
        btnPrintNew.Enabled = False
        btnSaveNew.Enabled = True
        btnUpdateNew.Enabled = False
        btnNewNew.Enabled = True
        btnCloseNew.Enabled = True
        btnGetDataNew.Enabled = True
        txtContactNo.Text = ""
        txtCustomerType.Text = ""
        auto()
        lblSet.Text = "Allowed"
        DataGridView1.Rows.Clear()
        DataGridView2.Rows.Clear()
        Clear()
        Clear1()
    End Sub

    Sub auto()
        Try
            txtID.Text = GenerateID()
            txtInvoiceNo.Text = "PB-" + GenerateID()
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
            cmd = New SqlCommand("SELECT TOP 1 Inv_ID FROM InvoiceInfo ORDER BY Inv_ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("Inv_ID")
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

    Sub Clear()
        txtProductCode.Text = ""
        txtProductName.Text = ""
        txtCostPrice.Text = ""
        txtSellingPrice.Text = ""
        txtMargin.Text = ""
        txtQty.Text = ""
        txtAmount.Text = ""
        txtDiscountPer.Text = ""
        txtDiscountAmount.Text = ""
        txtVAT.Text = ""
        txtVATAmount.Text = ""
        txtTotalAmount.Text = ""
        btnAdd.Enabled = True
        btnRemove.Enabled = False
        btnListUpdate.Enabled = False
    End Sub

    Sub Clear1()
        cmbPaymentMode.SelectedIndex = -1
        txtPayment.Text = "0.00"
        dtpPaymentDate.Text = Today
        btnPaymentAdd.Enabled = True
        btnPaymentRemove.Enabled = False
        btnPaymentUpdate.Enabled = False
    End Sub

    Private Sub btnSalesmanSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalesmanSelect.Click
        frmSalesmanRecord.lblSet.Text = "Sales"
        ' frmSalesmanRecord.lblUser.Text = lblUser.Text
        frmSalesmanRecord.Reset()
        frmSalesmanRecord.ShowDialog()
    End Sub

    Private Sub btnCustomerSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerSelect.Click
        frmCustomerRecord2.lblSet.Text = "Sales"
        frmCustomerRecord2.lblUser.Text = lblUser.Text
        frmCustomerRecord2.Reset()
        frmCustomerRecord2.ShowDialog()
    End Sub

    Private Sub btnSelectProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectProduct.Click
        frmProductRecord.lblSet.Text = "Billing"
        frmProductRecord.Reset()
        frmProductRecord.ShowDialog()
    End Sub

    Private Sub txtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.TextChanged
        compute()
    End Sub

    Sub Compute()
        Dim num1, num2, num3, num4, num5 As Double
        num1 = CDbl(Val(txtQty.Text) * Val(txtSellingPrice.Text))
        num1 = Math.Round(num1, 2)
        txtAmount.Text = num1
        num2 = CDbl((Val(txtAmount.Text) * Val(txtDiscountPer.Text)) / 100)
        num2 = Math.Round(num2, 2)
        txtDiscountAmount.Text = num2
        num3 = Val(txtAmount.Text) - Val(txtDiscountAmount.Text)
        num4 = CDbl((Val(txtVAT.Text) * Val(num3)) / 100)
        num4 = Math.Round(num4, 2)
        txtVATAmount.Text = num4
        num5 = CDbl(Val(txtAmount.Text) + Val(txtVATAmount.Text) - Val(txtDiscountAmount.Text))
        num5 = Math.Round(num5, 2)
        txtTotalAmount.Text = num5
    End Sub

    Private Sub txtQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnListReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListReset.Click
        Clear()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If txtProductCode.Text = "" Then
                MessageBox.Show("Please retrieve product code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProductCode.Focus()
                Exit Sub
            End If
            If Len(Trim(txtSellingPrice.Text)) = 0 Then
                MessageBox.Show("Please enter price", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSellingPrice.Focus()
                Exit Sub
            End If
            If Len(Trim(txtDiscountPer.Text)) = 0 Then
                MessageBox.Show("Please enter discount %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDiscountPer.Focus()
                Exit Sub
            End If
            If Len(Trim(txtVAT.Text)) = 0 Then
                MessageBox.Show("Please enter vat %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtVAT.Focus()
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
            If DataGridView1.Rows.Count = 0 Then
                DataGridView1.Rows.Add(txtProductCode.Text, txtProductName.Text, txtSellingPrice.Text, txtQty.Text, txtAmount.Text, txtDiscountPer.Text, txtDiscountAmount.Text, txtVAT.Text, txtVATAmount.Text, txtTotalAmount.Text, txtProductID.Text)
                Dim k As Double = 0
                k = GrandTotal()
                k = Math.Round(k, 2)
                txtGrandTotal.Text = k
                Clear()
                Exit Sub
            End If
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                If r.Cells(0).Value = txtProductCode.Text Then
                    r.Cells(0).Value = txtProductCode.Text
                    r.Cells(1).Value = txtProductName.Text
                    r.Cells(2).Value = txtSellingPrice.Text
                    r.Cells(3).Value = Val(r.Cells(3).Value) + Val(txtQty.Text)
                    r.Cells(4).Value = Val(r.Cells(4).Value) + Val(txtAmount.Text)
                    r.Cells(5).Value = Val(txtDiscountPer.Text)
                    r.Cells(6).Value = Val(r.Cells(6).Value) + Val(txtDiscountAmount.Text)
                    r.Cells(7).Value = Val(txtVAT.Text)
                    r.Cells(8).Value = Val(r.Cells(8).Value) + Val(txtVATAmount.Text)
                    r.Cells(9).Value = Val(r.Cells(9).Value) + Val(txtTotalAmount.Text)
                    r.Cells(10).Value = txtProductID.Text
                    Dim i As Double = 0
                    i = GrandTotal()
                    i = Math.Round(i, 2)
                    txtGrandTotal.Text = i
                    Clear()
                    Exit Sub
                End If
            Next
            DataGridView1.Rows.Add(txtProductCode.Text, txtProductName.Text, txtSellingPrice.Text, txtQty.Text, txtAmount.Text, txtDiscountPer.Text, txtDiscountAmount.Text, txtVAT.Text, txtVATAmount.Text, txtTotalAmount.Text, txtProductID.Text)
            Dim j As Double = 0
            j = GrandTotal()
            j = Math.Round(j, 2)
            txtGrandTotal.Text = j
            Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function GrandTotal() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + r.Cells(9).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Try
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
            Dim k As Double = 0
            k = GrandTotal()
            k = Math.Round(k, 2)
            txtGrandTotal.Text = k
            Compute()
            Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnListUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListUpdate.Click
        Try
            If txtProductCode.Text = "" Then
                MessageBox.Show("Please retrieve product code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProductCode.Focus()
                Exit Sub
            End If
            If Len(Trim(txtSellingPrice.Text)) = 0 Then
                MessageBox.Show("Please enter price", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSellingPrice.Focus()
                Exit Sub
            End If
            If Len(Trim(txtDiscountPer.Text)) = 0 Then
                MessageBox.Show("Please enter discount %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDiscountPer.Focus()
                Exit Sub
            End If
            If Len(Trim(txtVAT.Text)) = 0 Then
                MessageBox.Show("Please enter vat %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtVAT.Focus()
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
            DataGridView1.Rows.Add(txtProductCode.Text, txtProductName.Text, txtSellingPrice.Text, txtQty.Text, txtAmount.Text, txtDiscountPer.Text, txtDiscountAmount.Text, txtVAT.Text, txtVATAmount.Text, txtTotalAmount.Text, txtProductID.Text)
            Dim k As Double = 0
            k = GrandTotal()
            k = Math.Round(k, 2)
            txtGrandTotal.Text = k
            Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick

        If (Me.DataGridView1.Rows.Count > 0) Then
            If lblSet.Text = "Not Allowed" Then
                btnRemove.Enabled = False
                btnListUpdate.Enabled = False
            Else
                btnRemove.Enabled = True
                btnListUpdate.Enabled = True
            End If
            Me.btnAdd.Enabled = False
            Dim row As DataGridViewRow = Me.DataGridView1.SelectedRows.Item(0)
            Me.txtProductCode.Text = (row.Cells.Item(0).Value)
            Me.txtProductName.Text = (row.Cells.Item(1).Value)
            Me.txtSellingPrice.Text = (row.Cells.Item(2).Value)
            Me.txtQty.Text = (row.Cells.Item(3).Value)
            Me.txtAmount.Text = (row.Cells.Item(4).Value)
            Me.txtDiscountPer.Text = (row.Cells.Item(5).Value)
            Me.txtDiscountAmount.Text = (row.Cells.Item(6).Value)
            Me.txtVAT.Text = (row.Cells.Item(7).Value)
            Me.txtVATAmount.Text = (row.Cells.Item(8).Value)
            Me.txtTotalAmount.Text = (row.Cells.Item(9).Value)
            Me.txtProductID.Text = (row.Cells.Item(10).Value)
        End If
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

    Private Sub cmbPaymentMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPaymentMode.SelectedIndexChanged
        If cmbPaymentMode.SelectedIndex = 2 Or cmbPaymentMode.SelectedIndex = 3 Or cmbPaymentMode.SelectedIndex = 2 Or cmbPaymentMode.SelectedIndex = 4 Or cmbPaymentMode.SelectedIndex = 5 Or cmbPaymentMode.SelectedIndex = 6 Or cmbPaymentMode.SelectedIndex = 7 Then
            txtPayment.Text = "0.00"
            txtPayment.ReadOnly = True
        Else
            txtPayment.ReadOnly = False
        End If
    End Sub

    Private Sub btnPaymentAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaymentAdd.Click
        Try
            If DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("sorry no product added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If cmbPaymentMode.Text = "" Then
                MessageBox.Show("Please select payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbPaymentMode.Focus()
                Exit Sub
            End If
            If txtPayment.Text = "" Then
                MessageBox.Show("Please enter payment", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPayment.Focus()
                Exit Sub
            End If
            If DataGridView2.Rows.Count = 0 Then
                DataGridView2.Rows.Add(cmbPaymentMode.Text, txtPayment.Text, dtpPaymentDate.Text)
                Dim p As Double = 0
                'p = GrandTotal()
                p = TotalPayment()
                p = Math.Round(p, 2)
                txtTotalPayment.Text = p
                Compute1()
                Clear1()
                Exit Sub
            End If
            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                If r.Cells(0).Value = cmbPaymentMode.Text Then
                    r.Cells(0).Value = cmbPaymentMode.Text
                    r.Cells(1).Value = txtPayment.Text
                    r.Cells(2).Value = dtpPaymentDate.Text
                    Dim y As Double = 0
                    'y = GrandTotal()
                    y = TotalPayment()
                    y = Math.Round(y, 2)
                    'txtGrandTotal.Text = y
                    txtTotalPayment.Text = y
                    Compute1()
                    Clear1()
                    Exit Sub
                End If
            Next
            DataGridView2.Rows.Add(cmbPaymentMode.Text, txtPayment.Text, dtpPaymentDate.Text)
            Dim j As Double = 0
            j = TotalPayment()
            j = Math.Round(j, 2)
            txtTotalPayment.Text = j
            Compute1()
            Clear1()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function TotalPayment() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                sum = sum + r.Cells(1).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function

    Sub Compute1()
        Dim i As Double = 0
        i = Val(txtGrandTotal.Text) - Val(txtTotalPayment.Text)
        i = Math.Round(i, 2)
        txtPaymentDue.Text = i
    End Sub

    Private Sub btnPaymentReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaymentReset.Click
        Clear1()
    End Sub

    Private Sub btnPaymentRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaymentRemove.Click
        Try
            For Each row As DataGridViewRow In DataGridView2.SelectedRows
                DataGridView2.Rows.Remove(row)
            Next
            Dim k As Double = 0
            k = TotalPayment()
            k = Math.Round(k, 2)
            txtTotalPayment.Text = k
            Compute1()
            Compute()
            Clear1()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPaymentUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaymentUpdate.Click
        Try
            If DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("sorry no product added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If cmbPaymentMode.Text = "" Then
                MessageBox.Show("Please select payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbPaymentMode.Focus()
                Exit Sub
            End If
            If txtPayment.Text = "" Then
                MessageBox.Show("Please enter payment", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPayment.Focus()
                Exit Sub
            End If
            For Each row As DataGridViewRow In DataGridView2.SelectedRows
                DataGridView2.Rows.Remove(row)
            Next
            DataGridView2.Rows.Add(cmbPaymentMode.Text, Val(txtPayment.Text), dtpPaymentDate.Value.Date)
            Dim j As Double = 0
            j = TotalPayment()
            j = Math.Round(j, 2)
            txtTotalPayment.Text = j
            Compute1()
            Clear1()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView2_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView2.MouseClick
        'btnPaymentRemove.Enabled = True
        'If (Me.DataGridView2.Rows.Count > 0) Then
        '    Me.btnPaymentRemove.Enabled = True
        '    Me.btnPaymentUpdate.Enabled = True
        'End If
        If (Me.DataGridView2.Rows.Count > 0) Then
            If lblSet.Text = "Not Allowed" Then
                btnPaymentRemove.Enabled = False
                btnListUpdate.Enabled = False
            Else
                btnPaymentRemove.Enabled = True
                btnListUpdate.Enabled = True
            End If
            Me.btnPaymentAdd.Enabled = False
            Dim row As DataGridViewRow = Me.DataGridView2.SelectedRows.Item(0)
            Me.cmbPaymentMode.Text = (row.Cells.Item(0).Value)
            Me.txtPayment.Text = (row.Cells.Item(1).Value)
            'Me.dtpPaymentDate.Text = (row.Cells.Item(2).Value)
        End If
    End Sub

    Private Sub txtSellingPrice_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSellingPrice.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtSellingPrice.Text
            Dim selectionStart = Me.txtSellingPrice.SelectionStart
            Dim selectionLength = Me.txtSellingPrice.SelectionLength

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

    Private Sub txtDiscountPer_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscountPer.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtDiscountPer.Text
            Dim selectionStart = Me.txtDiscountPer.SelectionStart
            Dim selectionLength = Me.txtDiscountPer.SelectionLength

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

    Private Sub txtVAT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVAT.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtVAT.Text
            Dim selectionStart = Me.txtVAT.SelectionStart
            Dim selectionLength = Me.txtVAT.SelectionLength

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

    Private Sub txtSellingPrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSellingPrice.TextChanged
        Compute()
    End Sub

    Private Sub txtDiscountPer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscountPer.TextChanged
        Compute()
    End Sub

    Private Sub txtVAT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVAT.TextChanged
        Compute()
    End Sub

    Private Sub btnCloseNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseNew.Click
        Me.Close()
    End Sub


    Private Sub btnNewNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewNew.Click
        Reset()
    End Sub

    Private Sub btnSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveNew.Click
        If Len(Trim(txtSalesmanId.Text)) = 0 Then
            MessageBox.Show("Please retrieve salesman id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            btnSalesmanSelect.Focus()
            Exit Sub
        End If
        If Len(Trim(txtCustomerName.Text)) = 0 Then
            MessageBox.Show("Please retrieve or enter customer details", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Len(Trim(txtContactNo.Text)) = 0 Then
            MessageBox.Show("Please Enter Contact No.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContactNo.Focus()
            Exit Sub
        End If
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("sorry no product added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If DataGridView2.Rows.Count = 0 Then
            MessageBox.Show("sorry no payment info added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Val(txtTotalPayment.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("Total payment can not be more than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ctn1 As String = "select * from Company"
            cmd = New SqlCommand(ctn1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()

            If Not rdr.Read() Then
                MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim con As New SqlConnection(cs)
                con.Open()
                Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock where ProductID=@d1", con)
                cmd.Parameters.AddWithValue("@d1", Val(row.Cells(10).Value))
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As DataSet = New DataSet()
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    txtTotalQty.Text = ds.Tables(0).Rows(0)("Qty")
                    If CInt(Val(row.Cells(3).Value)) > Val(txtTotalQty.Text) Then
                        MessageBox.Show("added qty. to cart are more than" & vbCrLf & "available qty. of product code '" & row.Cells(0).Value.ToString() & "' and Product Name='" & row.Cells(1).Value & "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
                con.Close()
            Next
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into InvoiceInfo( Inv_ID, InvoiceNo, InvoiceDate, CustomerID, GrandTotal, TotalPaid, Balance, Remarks,SalesmanID) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8," & txtSM_ID.Text & ")"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Parameters.AddWithValue("@d2", txtInvoiceNo.Text)
            cmd.Parameters.AddWithValue("@d3", dtpInvoiceDate.Value.Date)
            cmd.Parameters.AddWithValue("@d4", Val(txtCID.Text))
            cmd.Parameters.AddWithValue("@d5", Val(txtGrandTotal.Text))
            cmd.Parameters.AddWithValue("@d6", Val(txtTotalPayment.Text))
            cmd.Parameters.AddWithValue("@d7", Val(txtPaymentDue.Text))
            cmd.Parameters.AddWithValue("@d8", txtRemarks.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            LedgerSave(dtpInvoiceDate.Value.Date, txtCustomerName.Text, txtInvoiceNo.Text, "Sales", Val(txtGrandTotal.Text), 0, txtCustomerID.Text)
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    If row.Cells(0).Value = "By Cash" Then
                        'LedgerSave(Convert.ToDateTime(row.Cells(2).Value), "Cash Account", txtInvoiceNo.Text, "Payment", 0, Val(row.Cells(1).Value), txtCustomerID.Text)'old code
                        LedgerSave(dtpPaymentDate.Value.Date, "Cash Account", txtInvoiceNo.Text, "Payment", 0, Val(row.Cells(1).Value), txtCustomerID.Text)
                    End If
                    If row.Cells(0).Value = "By Cheque" Or row.Cells(0).Value = "By Credit Card" Or row.Cells(0).Value = "By Debit Card" Then
                        LedgerSave(dtpPaymentDate.Value.Date, "Bank Account", txtInvoiceNo.Text, "Payment", 0, Val(row.Cells(1).Value), txtCustomerID.Text)
                    End If
                End If
            Next
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb4 As String = "update Temp_stock set qty = qty - (" & row.Cells(3).Value & ") where ProductID=@d1"
                    cmd = New SqlCommand(cb4)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(10).Value))
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            Next
            con.Close()
            Dim st As String = "added the new bill (Products) having invoice no. '" & txtInvoiceNo.Text & "'"
            LogFunc(lblUser.Text, st)
            If CheckForInternetConnection() = True Then
                con = New SqlConnection(cs)
                con.Open()
                Dim ctn As String = "select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes'"
                cmd = New SqlCommand(ctn)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    st2 = rdr.GetValue(0)
                    Dim st3 As String = "Hello, " & txtCustomerName.Text & " you have successfully purchased the products having invoice no. " & txtInvoiceNo.Text & ""
                    SMSFunc(txtContactNo.Text, st3, st2)
                    SMS(st3)
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                End If
            End If
            con.Close()
            btnSave.Enabled = False
            RefreshRecords()
            MessageBox.Show("Successfully done", "Billing", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Print()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPrintNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintNew.Click
        Print()
    End Sub

    Sub Print()
        'Try
        '    If txtCustomerType.Text <> "Non Regular" Then
        '        Cursor = Cursors.WaitCursor
        '        Timer1.Enabled = True
        '        Dim rpt As New rptSales 'The report you created.
        '        Dim myConnection As SqlConnection
        '        Dim MyCommand, MyCommand1 As New SqlCommand()
        '        Dim myDA, myDA1 As New SqlDataAdapter()
        '        Dim myDS As New DataSet 'The DataSet you created.
        '        myConnection = New SqlConnection(cs)
        '        MyCommand.Connection = myConnection
        '        MyCommand1.Connection = myConnection
        '        MyCommand.CommandText = "SELECT Customer.ID, Customer.Name, Customer.Gender, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.ContactNo, Customer.EmailID, Customer.Remarks,Customer.Photo, InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.CustomerID , InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID, Invoice_Product.CostPrice, Invoice_Product.SellingPrice, Invoice_Product.Margin,Invoice_Product.Qty, Invoice_Product.Amount, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.VATPer, Invoice_Product.VAT, Invoice_Product.TotalAmount, Product.PID,Product.ProductCode, Product.ProductName FROM Customer INNER JOIN InvoiceInfo ON Customer.ID = InvoiceInfo.CustomerID INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID where InvoiceInfo.Invoiceno=@d1"
        '        MyCommand.Parameters.AddWithValue("@d1", txtInvoiceNo.Text)
        '        MyCommand1.CommandText = "SELECT * from Company"
        '        MyCommand.CommandType = CommandType.Text
        '        MyCommand1.CommandType = CommandType.Text
        '        myDA.SelectCommand = MyCommand
        '        myDA1.SelectCommand = MyCommand1
        '        myDA.Fill(myDS, "Quotation")
        '        myDA.Fill(myDS, "Quotation_Join")
        '        myDA.Fill(myDS, "Customer")
        '        myDA.Fill(myDS, "Product")
        '        myDA1.Fill(myDS, "Company")
        '        rpt.SetDataSource(myDS)
        '        rpt.SetParameterValue("p1", txtCustomerID.Text)
        '        rpt.SetParameterValue("p2", Today)
        '        frmReport.CrystalReportViewer1.ReportSource = rpt
        '        frmReport.ShowDialog()
        '    End If
        '    If txtCustomerType.Text = "Non Regular" Then
        '        Cursor = Cursors.WaitCursor
        '        Timer1.Enabled = True
        '        Dim rpt As New rptQuotation1 'The report you created.
        '        Dim myConnection As SqlConnection
        '        Dim MyCommand, MyCommand1 As New SqlCommand()
        '        Dim myDA, myDA1 As New SqlDataAdapter()
        '        Dim myDS As New DataSet 'The DataSet you created.
        '        myConnection = New SqlConnection(cs)
        '        MyCommand.Connection = myConnection
        '        MyCommand1.Connection = myConnection
        '        MyCommand.CommandText = "SELECT Customer.ID, Customer.Name, Customer.Gender, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.ContactNo, Customer.EmailID, Customer.Remarks,Customer.Photo, InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.CustomerID , InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID, Invoice_Product.CostPrice, Invoice_Product.SellingPrice, Invoice_Product.Margin,Invoice_Product.Qty, Invoice_Product.Amount, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.VATPer, Invoice_Product.VAT, Invoice_Product.TotalAmount, Product.PID,Product.ProductCode, Product.ProductName FROM Customer INNER JOIN InvoiceInfo ON Customer.ID = InvoiceInfo.CustomerID INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID where InvoiceInfo.Invoiceno=@d1"
        '        MyCommand.Parameters.AddWithValue("@d1", txtInvoiceNo.Text)
        '        MyCommand1.CommandText = "SELECT * from Company"
        '        MyCommand.CommandType = CommandType.Text
        '        MyCommand1.CommandType = CommandType.Text
        '        myDA.SelectCommand = MyCommand
        '        myDA1.SelectCommand = MyCommand1
        '        myDA.Fill(myDS, "Quotation")
        '        myDA.Fill(myDS, "Quotation_Join")
        '        myDA.Fill(myDS, "Customer")
        '        myDA.Fill(myDS, "Product")
        '        myDA1.Fill(myDS, "Company")
        '        rpt.SetDataSource(myDS)
        '        rpt.SetParameterValue("p1", txtCustomerID.Text)
        '        rpt.SetParameterValue("p2", Today)
        '        frmReport.CrystalReportViewer1.ReportSource = rpt
        '        frmReport.ShowDialog()
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

        Try
            If txtCustomerType.Text <> "Non Regular" Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                Dim rpt As New rptSales1 'The report you created.
                Dim myConnection As SqlConnection
                Dim MyCommand, MyCommand1 As New SqlCommand()
                Dim myDA, myDA1 As New SqlDataAdapter()
                Dim myDS As New DataSet 'The DataSet you created.
                myConnection = New SqlConnection(cs)
                MyCommand.Connection = myConnection
                MyCommand1.Connection = myConnection
                MyCommand.CommandText = "SELECT Customer.ID, Customer.Name, Customer.Gender, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.ContactNo, Customer.EmailID, Customer.Remarks,Customer.Photo, InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.CustomerID , InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID, Invoice_Product.CostPrice, Invoice_Product.SellingPrice, Invoice_Product.Margin,Invoice_Product.Qty, Invoice_Product.Amount, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.VATPer, Invoice_Product.VAT, Invoice_Product.TotalAmount, Product.PID,Product.ProductCode, Product.ProductName FROM Customer INNER JOIN InvoiceInfo ON Customer.ID = InvoiceInfo.CustomerID INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID where InvoiceInfo.Invoiceno=@d1"
                MyCommand.Parameters.AddWithValue("@d1", txtInvoiceNo.Text)
                MyCommand1.CommandText = "SELECT * from Company"
                MyCommand1.CommandType = CommandType.Text
                rpt.SetDataSource(myDS)
                rpt.SetParameterValue("p1", txtCustomerID.Text)
                rpt.SetParameterValue("p2", Today)
                frmReport.CrystalReportViewer1.ReportSource = rpt
                frmReport.ShowDialog()
            End If
            If txtCustomerType.Text = "Non Regular" Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                '  Dim rpt As New rptInvoice2 'The report you created.
                Dim myConnection As SqlConnection
                Dim MyCommand, MyCommand1 As New SqlCommand()
                Dim myDA, myDA1 As New SqlDataAdapter()
                Dim myDS As New DataSet 'The DataSet you created.
                myConnection = New SqlConnection(cs)
                MyCommand.Connection = myConnection
                MyCommand1.Connection = myConnection
                MyCommand.CommandText = "SELECT Customer.ID, Customer.Name, Customer.Gender, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.ContactNo, Customer.EmailID, Customer.Remarks,Customer.Photo, InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.CustomerID , InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID, Invoice_Product.CostPrice, Invoice_Product.SellingPrice, Invoice_Product.Margin,Invoice_Product.Qty, Invoice_Product.Amount, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.VATPer, Invoice_Product.VAT, Invoice_Product.TotalAmount, Product.PID,Product.ProductCode, Product.ProductName FROM Customer INNER JOIN InvoiceInfo ON Customer.ID = InvoiceInfo.CustomerID INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID where InvoiceInfo.Invoiceno=@d1"
                MyCommand.Parameters.AddWithValue("@d1", txtInvoiceNo.Text)
                MyCommand1.CommandText = "SELECT * from Company"
                MyCommand.CommandType = CommandType.Text
                MyCommand1.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA1.SelectCommand = MyCommand1
                myDA.Fill(myDS, "InvoiceInfo")
                myDA.Fill(myDS, "Invoice_Product")
                myDA.Fill(myDS, "Customer")
                myDA.Fill(myDS, "Product")
                myDA1.Fill(myDS, "Company")

                frmReport.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnGetDataNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDataNew.Click

    End Sub
End Class

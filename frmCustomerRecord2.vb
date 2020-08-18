Imports System.Data.SqlClient

Imports System.IO

Public Class frmCustomerRecord2

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID),RTRIM(CustomerID),RTRIM([Name]),RTRIM(Gender), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(Remarks),Photo from Customer where CustomerType='Regular' order by ID", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub

    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                If lblSet.Text = "Services" Then
                    frmServices.Show()
                    Me.Hide()
                    frmServices.txtCID.Text = dr.Cells(0).Value.ToString
                    frmServices.txtCustomerID.Text = dr.Cells(1).Value.ToString()
                    frmServices.txtCustomerName.Text = dr.Cells(2).Value.ToString()
                    lblSet.Text = ""
                End If
                If lblSet.Text = "Quotation" Then
                    frmQuotation.Show()
                    Me.Hide()
                    frmQuotation.txtCID.Text = dr.Cells(0).Value.ToString
                    frmQuotation.txtCustomerID.Text = dr.Cells(1).Value.ToString()
                    frmQuotation.txtCustomerName.Text = dr.Cells(2).Value.ToString()
                    frmQuotation.txtContactNo.Text = dr.Cells(8).Value.ToString()
                    lblSet.Text = ""
                End If
                If lblSet.Text = "Billing" Then
                    'frmSales.Show()
                    'Me.Hide()
                    'frmSales.txtCID.Text = dr.Cells(0).Value.ToString
                    'frmSales.txtCustomerID.Text = dr.Cells(1).Value.ToString()
                    'frmSales.txtCustomerName.Text = dr.Cells(2).Value.ToString()
                    'frmSales.txtContactNo.Text = dr.Cells(8).Value.ToString()
                    'lblSet.Text = ""
                    frmBilling.Show()
                    Me.Hide()
                    frmBilling.txtCID.Text = dr.Cells(0).Value.ToString()
                    frmBilling.txtCustomerID.Text = dr.Cells(1).Value.ToString()
                    frmBilling.txtCustomerName.Text = dr.Cells(2).Value.ToString()
                    frmBilling.txtContactNo.Text = dr.Cells(8).Value.ToString()
                    frmBilling.txtCustomerName.ReadOnly = True
                    frmBilling.txtContactNo.ReadOnly = True
                    lblSet.Text = ""
                End If
                If lblSet.Text = "Manufactured" Then
                    frmBPBilling.Show()
                    Me.Hide()
                    frmBPBilling.txtCID.Text = dr.Cells(0).Value.ToString()
                    frmBPBilling.txtCustomerID.Text = dr.Cells(1).Value.ToString()
                    frmBPBilling.txtCustomerName.Text = dr.Cells(2).Value.ToString()
                    frmBPBilling.txtContactNo.Text = dr.Cells(8).Value.ToString()
                    frmBPBilling.txtCustomerName.ReadOnly = True
                    frmBPBilling.txtContactNo.ReadOnly = True
                    lblSet.Text = ""
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

    Private Sub txtCustomerName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCustomerName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID),RTRIM(CustomerID),RTRIM([Name]),RTRIM(Gender), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(Remarks),Photo from Customer where CustomerType='Regular' and name like '%" & txtCustomerName.Text & "%' order by ID", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCity_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCity.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID),RTRIM(CustomerID),RTRIM([Name]),RTRIM(Gender), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(Remarks),Photo from Customer where CustomerType='Regular' and City like '%" & txtCity.Text & "%' order by ID", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        txtCustomerName.Text = ""
        txtContactNo.Text = ""
        txtCity.Text = ""
        Getdata()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Reset()
    End Sub

    Private Sub txtContactNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtContactNo.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID),RTRIM(CustomerID),RTRIM([Name]),RTRIM(Gender), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(Remarks),Photo from Customer where CustomerType='Regular' and ContactNo like '%" & txtContactNo.Text & "%' order by ID", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        frmCustomer.lblUser.Text = lblUser.Text
        frmCustomer.Reset()
        frmCustomer.Reset()
        frmCustomer.ShowDialog()
    End Sub

    Private Sub dgw_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw.CellContentClick

    End Sub
End Class

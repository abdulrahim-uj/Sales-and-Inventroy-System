Imports System.Data.SqlClient

Imports System.IO

Public Class frmSalesmanRecord

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT SM_ID,RTRIM(Salesman_ID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),CommissionPer,RTRIM(Remarks),Photo from Salesman order by name", con)
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

    Private Sub txtSalesmanName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSalesmanName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT SM_ID,RTRIM(Salesman_ID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),CommissionPer,RTRIM(Remarks),Photo from Salesman where name like '%" & txtSalesmanName.Text & "%' order by name", con)
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
            cmd = New SqlCommand("SELECT SM_ID,RTRIM(Salesman_ID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),CommissionPer,RTRIM(Remarks),Photo from Salesman where City like '%" & txtCity.Text & "%' order by Name", con)
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
        txtSalesmanName.Text = ""
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
            cmd = New SqlCommand("SELECT SM_ID,RTRIM(Salesman_ID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),CommissionPer,RTRIM(Remarks),Photo from Salesman where ContactNo like '%" & txtContactNo.Text & "%' order by Name", con)
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

    Private Sub btnClose_Click_1(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dgw_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                If lblSet.Text = "Salesman Entry" Then
                    frmSalesman.Show()
                    Me.Hide()
                    frmSalesman.txtSM_ID.Text = dr.Cells(0).Value.ToString()
                    frmSalesman.txtSalesmanID.Text = dr.Cells(1).Value.ToString()
                    frmSalesman.txtSalesmanName.Text = dr.Cells(2).Value.ToString()
                    frmSalesman.txtAddress.Text = dr.Cells(3).Value.ToString()
                    frmSalesman.txtCity.Text = dr.Cells(4).Value.ToString()
                    frmSalesman.cmbState.Text = dr.Cells(5).Value.ToString()
                    frmSalesman.txtZipCode.Text = dr.Cells(6).Value.ToString()
                    frmSalesman.txtContactNo.Text = dr.Cells(7).Value.ToString()
                    frmSalesman.txtEmailID.Text = dr.Cells(8).Value.ToString()
                    frmSalesman.txtCommissionPer.Text = dr.Cells(9).Value.ToString()
                    frmSalesman.txtRemarks.Text = dr.Cells(10).Value.ToString()
                    Dim data As Byte() = DirectCast(dr.Cells(11).Value, Byte())
                    Dim ms As New MemoryStream(data)
                    frmSalesman.Picture.Image = Image.FromStream(ms)
                    frmSalesman.btnUpdate.Enabled = True
                    frmSalesman.btnDelete.Enabled = True
                    frmSalesman.btnSave.Enabled = False
                    lblSet.Text = ""
                End If
                If lblSet.Text = "Billing" Then
                    frmBilling.Show()
                    Me.Hide()
                    frmBilling.txtSM_ID.Text = dr.Cells(0).Value.ToString()
                    frmBilling.txtSalesmanId.Text = dr.Cells(1).Value.ToString()
                    frmBilling.txtSalesmanName.Text = dr.Cells(2).Value.ToString()
                    frmBilling.txtCommissionPer.Text = dr.Cells(9).Value.ToString()
                    lblSet.Text = ""
                End If
                If lblSet.Text = "Manufactured" Then
                    frmBPBilling.Show()
                    Me.Hide()
                    frmBPBilling.txtSM_ID.Text = dr.Cells(0).Value.ToString()
                    frmBPBilling.txtSalesmanId.Text = dr.Cells(1).Value.ToString()
                    frmBPBilling.txtSalesmanName.Text = dr.Cells(2).Value.ToString()
                    frmBPBilling.txtCommissionPer.Text = dr.Cells(9).Value.ToString()
                    lblSet.Text = ""
                End If
                If lblSet.Text = "Report need" Then

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgw_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub
    Private Sub frmSalesmanRecord_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub

    Private Sub dgw_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw.CellContentClick

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class

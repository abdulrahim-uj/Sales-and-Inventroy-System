Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Public Class frmActivation

    Private Sub frmActivation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Dim i As System.Management.ManagementObject
            Dim searchInfo_Processor As New System.Management.ManagementObjectSearcher("Select * from Win32_Processor")
            For Each i In searchInfo_Processor.Get()
                txtHardwareID.Text = i("ProcessorID").ToString
            Next
            Dim searchInfo_Board As New System.Management.ManagementObjectSearcher("Select * from Win32_BaseBoard")
            For Each i In searchInfo_Board.Get()
                txtSerialNo.Text = i("SerialNumber").ToString
                If txtSerialNo.Text = "" Then
                    txtSerialNo.Text = "RBCXF-CVBGR-382MK-DFHJ4-C69G8"
                End If
            Next
            ''WIN32_PROCESSOR
            'Dim searchInfo_Processor As New System.Management.ManagementObjectSearcher("Select * from Win32_Processor")
            'For Each i In searchInfo_Processor.Get()
            '    txtHardwareID.Text = i("ProcessorID").ToString
            'Next
            'Dim searchInfo_PManufacturer As New System.Management.ManagementObjectSearcher("Select * from Win32_Processor")
            'For Each i In searchInfo_PManufacturer.Get()
            '    txtManufacturer.Text = i("Manufacturer").ToString
            'Next
            'Dim searchInfo_PName As New System.Management.ManagementObjectSearcher("Select * from Win32_Processor")
            'For Each i In searchInfo_PName.Get()
            '    txtName.Text = i("Name").ToString
            'Next
            'Dim searchInfo_PDescription As New System.Management.ManagementObjectSearcher("Select * from Win32_Processor")
            'For Each i In searchInfo_PDescription.Get()
            '    txtDescription.Text = i("Description").ToString
            'Next
            'Dim searchInfo_PArchitecture As New System.Management.ManagementObjectSearcher("Select * from Win32_Processor")
            'For Each i In searchInfo_PArchitecture.Get()
            '    txtArchitecture.Text = i("Architecture").ToString
            'Next
            'Dim searchInfo_PAddresswidth As New System.Management.ManagementObjectSearcher("Select * from Win32_Processor")
            'For Each i In searchInfo_PAddresswidth.Get()
            '    txtAddresswidth.Text = i("AddressWidth").ToString
            'Next
            'Dim searchInfo_PNumberofcores As New System.Management.ManagementObjectSearcher("Select * from Win32_Processor")
            'For Each i In searchInfo_PNumberofcores.Get()
            '    txtNumberofcores.Text = i("NumberOfCores").ToString
            'Next
            'Dim searchInfo_PDatawidth As New System.Management.ManagementObjectSearcher("Select * from Win32_Processor")
            'For Each i In searchInfo_PDatawidth.Get()
            '    txtDatawidth.Text = i("DataWidth").ToString
            'Next
            'Dim searchInfo_PFamily As New System.Management.ManagementObjectSearcher("Select * from Win32_Processor")
            'For Each i In searchInfo_PFamily.Get()
            '    txtFamily.Text = i("Family").ToString
            'Next
            'Dim searchInfo_PMaxclockspeed As New System.Management.ManagementObjectSearcher("Select * from Win32_Processor")
            'For Each i In searchInfo_PMaxclockspeed.Get()
            '    txtMaxclockspeed.Text = i("MaxClockSpeed").ToString
            'Next
            ''WIN32_BASEBOARD
            'Dim searchInfo_Board As New System.Management.ManagementObjectSearcher("Select * from Win32_BaseBoard")
            'For Each i In searchInfo_Board.Get()
            '    txtSerialNo.Text = i("SerialNumber")
            '    If txtSerialNo.Text = "" Then
            '        txtSerialNo.Text = "RBCXF-CVBGR-382MK-DFHJ4-C69G8"
            '    End If
            'Next
            'Dim searchInfo_BConfigoptions As New System.Management.ManagementObjectSearcher("Select * from Win32_BaseBoard")
            'For Each i In searchInfo_BConfigoptions.Get()
            '    txtConfigoptions.Text = i("ConfigOptions")
            'Next
            'Dim searchInfo_BDepth As New System.Management.ManagementObjectSearcher("Select * from Win32_BaseBoard")
            'For Each i In searchInfo_BDepth.Get()
            '    txtDepth.Text = i("Depth")
            'Next
            'Dim searchInfo_BHostingbird As New System.Management.ManagementObjectSearcher("Select * from Win32_BaseBoard")
            'For Each i In searchInfo_BHostingbird.Get()
            '    txtHostingbird.Text = i("HostingBoard")
            'Next
            'Dim searchInfo_BHotswappable As New System.Management.ManagementObjectSearcher("Select * from Win32_BaseBoard")
            'For Each i In searchInfo_BHotswappable.Get()
            '    txtHotswappable.Text = i("HotSwappable")
            'Next
            'Dim searchInfo_BBManufacurer As New System.Management.ManagementObjectSearcher("Select * from Win32_BaseBoard")
            'For Each i In searchInfo_BBManufacurer.Get()
            '    txtBBManufacturer.Text = i("Manufacturer")
            'Next
            'Dim searchInfo_BModel As New System.Management.ManagementObjectSearcher("Select * from Win32_BaseBoard")
            'For Each i In searchInfo_BModel.Get()
            '    txtModel.Text = i("Model")
            'Next
            'Dim searchInfo_BBName As New System.Management.ManagementObjectSearcher("Select * from Win32_BaseBoard")
            'For Each i In searchInfo_BBName.Get()
            '    txtBBName.Text = i("Name")
            'Next
            'Dim searchInfo_BOtheridentifyinginfo As New System.Management.ManagementObjectSearcher("Select * from Win32_BaseBoard")
            'For Each i In searchInfo_BOtheridentifyinginfo.Get()
            '    txtOtheridentifyinginfo.Text = i("OtherIdentifyingInfo")
            'Next
            'Dim searchInfo_BSKU As New System.Management.ManagementObjectSearcher("Select * from Win32_BaseBoard")
            'For Each i In searchInfo_BSKU.Get()
            '    txtSKU.Text = i("SKU")
            'Next
            'Dim searchInfo_BSpecialRequirements As New System.Management.ManagementObjectSearcher("Select * from Win32_BaseBoard")
            'For Each i In searchInfo_BSpecialRequirements.Get()
            '    txtSpecialrequirements.Text = i("SpecialRequirements")
            'Next
            'Dim searchInfo_BBVersion As New System.Management.ManagementObjectSearcher("Select * from Win32_BaseBoard")
            'For Each i In searchInfo_BBVersion.Get()
            '    txtBBVersion.Text = i("Version")
            'Next
            ''WIN32_OPERATINGSYSTEM
            'Dim searchInfo_OSVersion As New System.Management.ManagementObjectSearcher("Select * from Win32_OperatingSystem")
            'For Each i In searchInfo_OSVersion.Get()
            '    txtVersion.Text = i("Version").ToString
            'Next
            'Dim searchInfo_OScsname As New System.Management.ManagementObjectSearcher("Select * from Win32_OperatingSystem")
            'For Each i In searchInfo_OScsname.Get()
            '    txtCSName.Text = i("CSName").ToString
            'Next
            'Dim searchInfo_OSCaption As New System.Management.ManagementObjectSearcher("Select * from Win32_OperatingSystem")
            'For Each i In searchInfo_OSCaption.Get()
            '    txtCaption.Text = i("Caption").ToString
            'Next
            'Dim searchInfo_OSBuildnumber As New System.Management.ManagementObjectSearcher("Select * from Win32_OperatingSystem")
            'For Each i In searchInfo_OSBuildnumber.Get()
            '    txtBuildNumber.Text = i("BuildNumber").ToString
            'Next
            'Dim searchInfo_OSBuildtype As New System.Management.ManagementObjectSearcher("Select * from Win32_OperatingSystem")
            'For Each i In searchInfo_OSBuildtype.Get()
            '    txtBuildType.Text = i("BuildType").ToString
            'Next
            'Dim searchInfo_OSProductsuite As New System.Management.ManagementObjectSearcher("Select * from Win32_OperatingSystem")
            'For Each i In searchInfo_OSProductsuite.Get()
            '    txtOSProductsuite.Text = i("OSProductsuite").ToString
            'Next
            'Dim searchInfo_OSArchitecture As New System.Management.ManagementObjectSearcher("Select * from Win32_OperatingSystem")
            'For Each i In searchInfo_OSArchitecture.Get()
            '    txtOSArchitecture.Text = i("OSArchitecture").ToString
            'Next
            'Dim searchInfo_OSType As New System.Management.ManagementObjectSearcher("Select * from Win32_OperatingSystem")
            'For Each i In searchInfo_OSType.Get()
            '    txtOSType.Text = i("OSType").ToString
            'Next
            ''WIN32_COMPUTERSYSTEM
            'Dim searchInfo_CSNumberofProcessors As New System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem")
            'For Each i In searchInfo_CSNumberofProcessors.Get()
            '    txtNumberofProcessor.Text = i("NumberOfProcessors").ToString
            'Next
            'Dim searchInfo_CSNumberoflogicalProcessors As New System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem")
            'For Each i In searchInfo_CSNumberoflogicalProcessors.Get()
            '    txtNumberoflogicalProcessors.Text = i("NumberOfLogicalProcessors").ToString
            'Next
            'Dim searchInfo_CSpcSystemtype As New System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem")
            'For Each i In searchInfo_CSpcSystemtype.Get()
            '    txtPcSystemtype.Text = i("PCSystemType").ToString
            'Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error!")
            End
        End Try
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            If txtActivationID.Text = "" Then
                MessageBox.Show("Please enter activation id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtActivationID.Focus()
                Dim st1 As String = (txtHardwareID.Text) + (txtSerialNo.Text)
                TextBox1.Text = Encryption.MakePassword(st1, 659)
                'txtActivationID.Text = TextBox1.Text
                Exit Sub
            End If
            Dim st As String = (txtHardwareID.Text) + (txtSerialNo.Text)
            TextBox1.Text = Encryption.MakePassword(st, 659)

            If txtActivationID.Text = TextBox1.Text Then
                con = New SqlConnection(cs)
                con.Open()
                Dim cb1 As String = "insert into Activation(HardwareID,SerialNo,ActivationID) VALUES (@d1,@d2,@d3)"
                cmd = New SqlCommand(cb1)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", Encrypt(txtHardwareID.Text.Trim))
                cmd.Parameters.AddWithValue("@d2", Encrypt(txtSerialNo.Text.Trim))
                cmd.Parameters.AddWithValue("@d3", Encrypt(txtActivationID.Text.Trim()))
                cmd.ExecuteReader()
                con.Close()
                MessageBox.Show("Successfully activated", "Software", MessageBoxButtons.OK, MessageBoxIcon.Information)
                frmLogin.Show()
                Me.Hide()
            Else
                MessageBox.Show("Invalid activation id...Please contact software provider for buying full licence" & vbCrLf & "Contact us at :" & vbCrLf & "Raj Sharma" & vbCrLf & "Email-Sharma.raj@outlook.com" & vbCrLf & "Mobile No. +919827858191", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        End
    End Sub
End Class

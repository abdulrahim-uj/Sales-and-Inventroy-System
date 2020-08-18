Imports System.Data.SqlClient
Public Class frmSplash

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Try
            If System.IO.File.Exists(Application.StartupPath & "\SQLSettings.dat") Then
                If txtActivationID.Text = TextBox1.Text Then
                    ProgressBar1.Visible = True
                    ProgressBar1.Value = ProgressBar1.Value + 2
                    If (ProgressBar1.Value = 10) Then
                        lblSet.Text = "Reading modules.."
                    ElseIf (ProgressBar1.Value = 20) Then
                        lblSet.Text = "Turning on modules."
                    ElseIf (ProgressBar1.Value = 40) Then
                        lblSet.Text = "Starting modules.."
                    ElseIf (ProgressBar1.Value = 60) Then
                        lblSet.Text = "Loading modules.."
                    ElseIf (ProgressBar1.Value = 80) Then
                        lblSet.Text = "Done Loading modules.."
                    ElseIf (ProgressBar1.Value = 100) Then
                        frmLogin.Show()
                        Timer1.Enabled = False
                        Me.Hide()
                    End If
                End If
            Else
                ProgressBar1.Visible = True
                ProgressBar1.Value = ProgressBar1.Value + 2
                If (ProgressBar1.Value = 10) Then
                    lblSet.Text = "Reading modules.."
                ElseIf (ProgressBar1.Value = 20) Then
                    lblSet.Text = "Turning on modules."
                ElseIf (ProgressBar1.Value = 40) Then
                    lblSet.Text = "Starting modules.."
                ElseIf (ProgressBar1.Value = 60) Then
                    lblSet.Text = "Loading modules.."
                ElseIf (ProgressBar1.Value = 80) Then
                    lblSet.Text = "Done Loading modules.."
                ElseIf (ProgressBar1.Value = 100) Then
                    frmSqlServerSetting.Reset()
                    frmSqlServerSetting.Show()
                    Timer1.Enabled = False
                    Me.Hide()
                End If
            End If
            If System.IO.File.Exists(Application.StartupPath & "\SQLSettings.dat") Then
                If txtActivationID.Text <> TextBox1.Text Then
                    ProgressBar1.Visible = True
                    ProgressBar1.Value = ProgressBar1.Value + 2
                    If (ProgressBar1.Value = 10) Then
                        lblSet.Text = "Reading modules.."
                    ElseIf (ProgressBar1.Value = 20) Then
                        lblSet.Text = "Turning on modules."
                    ElseIf (ProgressBar1.Value = 40) Then
                        lblSet.Text = "Starting modules.."
                    ElseIf (ProgressBar1.Value = 60) Then
                        lblSet.Text = "Loading modules.."
                    ElseIf (ProgressBar1.Value = 80) Then
                        lblSet.Text = "Done Loading modules.."
                    ElseIf (ProgressBar1.Value = 100) Then
                        frmActivation.Show()
                        Timer1.Enabled = False
                        Me.Hide()
                    End If
                End If
            Else
                ProgressBar1.Visible = True
                ProgressBar1.Value = ProgressBar1.Value + 2
                If (ProgressBar1.Value = 10) Then
                    lblSet.Text = "Reading modules.."
                ElseIf (ProgressBar1.Value = 20) Then
                    lblSet.Text = "Turning on modules."
                ElseIf (ProgressBar1.Value = 40) Then
                    lblSet.Text = "Starting modules.."
                ElseIf (ProgressBar1.Value = 60) Then
                    lblSet.Text = "Loading modules.."
                ElseIf (ProgressBar1.Value = 80) Then
                    lblSet.Text = "Done Loading modules.."
                ElseIf (ProgressBar1.Value = 100) Then
                    frmSqlServerSetting.Reset()
                    frmSqlServerSetting.Show()
                    Timer1.Enabled = False
                    Me.Hide()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error!")
            End
        End Try

    End Sub

    Private Sub frmSplash1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            If System.IO.File.Exists(Application.StartupPath & "\SQLSettings.dat") Then
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
                Dim st As String = (txtHardwareID.Text) + (txtSerialNo.Text)
                TextBox1.Text = Encryption.MakePassword(st, 659)
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select RTRIM(ActivationID) from Activation where HardwareID=@d1 and SerialNo=@d2"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", Encrypt(txtHardwareID.Text.Trim))
                cmd.Parameters.AddWithValue("@d2", Encrypt(txtSerialNo.Text.Trim))
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    txtActivationID.Text = Decrypt(rdr.GetValue(0))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error!")
            End
        End Try
    End Sub

End Class
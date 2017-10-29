'Imports Microsoft.Office.Interop.Excel '
Imports Microsoft.Office.Interop
Imports System.Data.OleDb
Imports System.Data
Imports System.IO

Public Class FrmMain
    Dim objSolver As New clsSolver
    Public v_Tongvon As Double
    Public v_tonglaodong As Double
    Public v_slgDVDD As Integer
    Public v_slgLUT As Integer
    Public v_fileDVDD As String
    Public st_PT_Hammuctieu As String = ""
    Public st_PT_Rangbuocchiphi As String
    Public st_PT_RangbuocDientichTN_LUT() As String
    Public st_PT_RangbuocDientichDVDD() As String
    Public st_PT_RangbuocLaodong As String


    Private Sub mnuToiUuHoa_Click(sender As Object, e As EventArgs) Handles mnuToiUuHoa.Click
        Dim a As Integer

        System.Diagnostics.Debug.WriteLine(System.Runtime.InteropServices.Marshal.SizeOf(a))

        System.Diagnostics.Debug.WriteLine(CurDir())
        lpsolve55.Init(".")
        '   System.Diagnostics.Debug.WriteLine("bat dau phan toi uu")
        objSolver.Test()
    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        End
    End Sub

    Private Sub mnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click
        Dim frmAbout1 As New frmAbout
        frmAbout1.ShowDialog()
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'load_shp()

    End Sub

   


    Private Sub mnuNewProject_Click(sender As Object, e As EventArgs) Handles mnuNewProject.Click
        Dim frmNewProj1 As New frmNewProject
        frmNewProj1.ShowDialog()
    End Sub

    Private Sub toolNew_Click(sender As Object, e As EventArgs) Handles toolNew.Click
        mnuNewProject.PerformClick()
    End Sub

    Private Sub toolOpen_Click(sender As Object, e As EventArgs) Handles toolOpen.Click
        mnuOpenProject.PerformClick()
    End Sub

    Private Sub toolChayToiuu_Click(sender As Object, e As EventArgs) Handles toolChayToiuu.Click
        mnuToiUuHoa.PerformClick()
    End Sub


    Private Sub cmdTaoPhtrinh_Click(sender As Object, e As EventArgs) Handles cmdTaoPhtrinh.Click
        createHammuctieu()
        createRangbuocDientichTN_LUT()
        createRangbuocDientichTN_DVDD()
        createRangbuocLaodong()
        ' ghi phuong trinh ra tạp tin 
        'Dim file As System.IO.StreamWriter
        'file = My.Computer.FileSystem.OpenTextFileWriter(CurDir() & "\hephuongtrinh.lp", False)
        'file.WriteLine(st_PT_Hammuctieu)
        'For i = 0 To v_slgLUT - 1
        '    file.WriteLine(st_PT_RangbuocDientichTN_LUT(i))
        'Next
        'For i = 0 To v_slgDVDD - 1
        '    file.WriteLine(st_PT_RangbuocDientichDVDD(i))
        'Next

        'file.Close()
        Dim file As System.IO.FileStream
        'LoadStream = New StreamWriter(OutputFile, False, System.Text.Encoding.Default)
        Try
            ' Indicate whether the text file exists
            If Not My.Computer.FileSystem.FileExists(CurDir() & "\hephuongtrinh.lp") Then
                ' Try to create the text file with all the info in it
                file = System.IO.File.Create(CurDir() & "\hephuongtrinh.lp")
                file.Close()
            End If
            Dim addInfo As System.IO.StreamWriter
            addInfo = My.Computer.FileSystem.OpenTextFileWriter(CurDir() & "\hephuongtrinh.lp", False, System.Text.Encoding.Default)
            ' System.Text.Encoding.Default: Để ghi file dạng ANSI bình thường ( Unicode LPSolve đọc lỗi)

            addInfo.WriteLine(st_PT_Hammuctieu)
            For i = 0 To v_slgLUT - 1
                addInfo.WriteLine(st_PT_RangbuocDientichTN_LUT(i))
            Next
            For i = 0 To v_slgDVDD - 1
                addInfo.WriteLine(st_PT_RangbuocDientichDVDD(i))
            Next
            addInfo.WriteLine(st_PT_RangbuocLaodong)
            addInfo.Close()
        Catch
        End Try
        MsgBox("Đã xây dựng hệ phương trình tối ưu xong")
        'Dim file1 As StreamWriter
        'If Not My.Computer.FileSystem.FileExists("d:\test.txt") Then
        '    ' Try to create the text file with all the info in it
        '    '    file1 = New StreamWriter("d:\test.txt", False, System.Text.Encoding.Default) 'System.IO.File.Create("d:\test.txt")
        'End If
        ''file1 As System.IO.StreamWriter
        'file1 = My.Computer.FileSystem.OpenTextFileWriter("d:\test.txt", False, System.Text.Encoding.Default)
        'file1.WriteLine("Here is the first string aa.")
        'file1.Close()
    End Sub
    Private Sub createHammuctieu()
        ' Tạo hàm mục tiêu 
        st_PT_Hammuctieu = " max: "
        Dim i As Integer = 0
        Dim j As Integer = 0
        For i = 0 To v_slgDVDD - 1  ' Duyệt số dòng của grdLoinhuan
            For j = 1 To v_slgLUT  ' DUyệt số cột của grdLoinhuan
                'Mỗi dòng ( 5 Lut * LD của từng lut * MT của từng LUT
                st_PT_Hammuctieu = st_PT_Hammuctieu & "+" & grdThichNghi.Rows(i).Cells(j).Value * grdLoinhuan.Rows(i).Cells(j).Value * grdMoitruong.Item(1, j).Value * grdLaodong.Item(1, j).Value & "x" & (i + 1) & j
            Next
        Next
        st_PT_Hammuctieu = st_PT_Hammuctieu & " ;"
        'MsgBox(st_PT_Hammuctieu)  xc
    End Sub
    Private Sub createRangbuocDientichTN_LUT()
        ' Ràng buộc tổng diện tích của LUT (i) >= diện tích tối thiểu yêu cầu của LUT (i)
        Dim i As Integer = 0
        Dim j As Integer = 0
        ReDim Preserve st_PT_RangbuocDientichTN_LUT(v_slgLUT)

        'Array.Resize(st_PT_Rangbuocchiphi, v_slgDVDD)
        For j = 0 To v_slgLUT - 1   ' Duyệt số cot ( so LUT ) của grdTN  ; Cot 0 la co DVDD nhung de dien vao cot 0 cua phuong trinh
            st_PT_RangbuocDientichTN_LUT(j) = ""
            For i = 0 To v_slgDVDD - 1 ' DUyệt số dòng của grdTN   (số DVDĐ)
                st_PT_RangbuocDientichTN_LUT(j) = st_PT_RangbuocDientichTN_LUT(j) & "+" & grdThichNghi.Rows(i).Cells(j + 1).Value & "x" & (i + 1) & (j + 1)
            Next
            st_PT_RangbuocDientichTN_LUT(j) = st_PT_RangbuocDientichTN_LUT(j) & " >= " & grdRangbuoc.Rows(j).Cells(1).Value & " ;" ' cột 1 trong grdRangbuoc  chứa diện tích ràng buộc của LUT
            '  MsgBox(" PT rang buoc DT LUT:" & st_PT_RangbuocDientichTN_LUT(i))
        Next

    End Sub
    Private Sub createRangbuocDientichTN_DVDD()
        ' Điều kiện Tổng diện tích các LUT cần tìm trong một DVDD(i) <= diện tích của ĐVDD(i)
        Dim i As Integer = 0
        Dim j As Integer = 0
        ReDim Preserve st_PT_RangbuocDientichDVDD(v_slgDVDD)

        'Array.Resize(st_PT_Rangbuocchiphi, v_slgDVDD)
        For i = 0 To v_slgDVDD - 1  ' Duyệt số dòng của grdLoinhuan
            st_PT_RangbuocDientichDVDD(i) = ""
            For j = 1 To v_slgLUT  ' DUyệt số cột của grdLoinhuan
                st_PT_RangbuocDientichDVDD(i) = st_PT_RangbuocDientichDVDD(i) & "+" & grdThichNghi.Rows(i).Cells(j).Value & "x" & (i + 1) & j
            Next
            st_PT_RangbuocDientichDVDD(i) = st_PT_RangbuocDientichDVDD(i) & " <= " & grdDVDD.Rows(i).Cells(1).Value & " ;"  ' cột 1 trong grdDVDDD chứa diện tích của ĐVĐĐ
            ' MsgBox("PT rang buoc DT DVĐ:" & st_PT_RangbuocDientichDVDD(i))
        Next

    End Sub
    Private Sub createRangbuocLaodong()
        ' Điều kiện Tổng lao dộng cho các LUTi * dt_LUTi <= Tong lao dong
        Dim i As Integer = 0
        Dim j As Integer = 0
        
        st_PT_RangbuocLaodong = ""
        For i = 0 To v_slgDVDD - 1  ' Duyệt số dòng của grdLoinhuan
            For j = 1 To v_slgLUT  ' DUyệt số cột của grdLoinhuan
                st_PT_RangbuocLaodong = st_PT_RangbuocLaodong & "+" & grdThichNghi.Rows(i).Cells(j).Value * grdLaodong.Item(1, j).Value & "x" & (i + 1) & j
            Next
           
        Next
        st_PT_RangbuocLaodong = st_PT_RangbuocLaodong & " <= " & Val(txtTogngaycong.Text) & " ;"
        ' MsgBox("PT rang buoc DT DVĐ:" & st_PT_RangbuocLaodong
    End Sub

    Private Sub cmdChayToiuu_Click(sender As Object, e As EventArgs) Handles cmdChayToiuu.Click
        Dim a As Integer

        System.Diagnostics.Debug.WriteLine(System.Runtime.InteropServices.Marshal.SizeOf(a))

        System.Diagnostics.Debug.WriteLine(CurDir())
        'lpsolve55.Init(".")
        lpsolve55.Init(".")
        '   System.Diagnostics.Debug.WriteLine("bat dau phan toi uu")
        createGrdKetqua()
        objSolver.LUOptimizer()


    End Sub

    Private Sub mnuLuu_Click(sender As Object, e As EventArgs) Handles mnuLuu.Click

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As New Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value

        Dim i As Int16, j As Int16
        'Try
        xlApp = New Microsoft.Office.Interop.Excel.Application 'New Excel.ApplicationClass
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        'Export thongtinchung sang excel
        xlWorkSheet = xlWorkBook.Sheets.Add()
        xlWorkSheet.Name = "THONGTINCHUNG"

        xlWorkSheet.Cells(1, 1) = "SLG_DVDD"
        xlWorkSheet.Cells(2, 1) = v_slgDVDD
        xlWorkSheet.Cells(1, 2) = "SLG_LUT"
        xlWorkSheet.Cells(2, 2) = v_slgLUT
        xlWorkSheet.Cells(1, 3) = "SLG_LAODONG"
        xlWorkSheet.Cells(2, 3) = v_tonglaodong
        xlWorkSheet.Cells(1, 4) = "TONGVON"
        xlWorkSheet.Cells(2, 4) = v_Tongvon
        xlWorkSheet.Cells(1, 5) = "file_dvdd"
        xlWorkSheet.Cells(2, 5) = v_fileDVDD
        'Export RB_dientich_LUT sang excel
        xlWorkSheet = xlWorkBook.Sheets.Add()
        xlWorkSheet.Name = "DIENTICH_LUT"
        ' Ghi tiêu đề cột
        xlWorkSheet.Cells(1, 1) = "LUT"
        xlWorkSheet.Cells(1, 2) = "DIENTICH"
        For i = 0 To v_slgLUT - 1
            For j = 0 To 1 ' grdLUT có 2 cột
                xlWorkSheet.Cells(i + 2, j + 1) = grdRangbuoc(j, i).Value
            Next
        Next


        'Export DVĐ_LN sang excel
        xlWorkSheet = xlWorkBook.Sheets.Add()
        xlWorkSheet.Name = "DVDD_LN"
        ' Ghi tiêu đề cột

        xlWorkSheet.Cells(1, 1) = "LUT"
        xlWorkSheet.Cells(1, 2) = "loinhuan"
    
        For i = 0 To v_slgLUT - 1
            For j = 0 To 1 ' 
                xlWorkSheet.Cells(i + 2, j + 1) = grdLoinhuan(j, i).Value
            Next
        Next
        'Export DVDD_CP sang excel
        xlWorkSheet = xlWorkBook.Sheets.Add()
        xlWorkSheet.Name = "DVDD_CP"

        ' Ghi tiêu đề cột
        xlWorkSheet.Cells(1, 1) = "LUT"
        xlWorkSheet.Cells(1, 2) = "chiphi"

        For i = 0 To v_slgLUT - 1
            For j = 0 To 1 ' grdLUT có 2 cột
                xlWorkSheet.Cells(i + 2, j + 1) = grdChiphi(j, i).Value
            Next
        Next

        'Export DVDD_Thichnghi sang excel
        xlWorkSheet = xlWorkBook.Sheets.Add()
        xlWorkSheet.Name = "DVDD_TN"
        ' Ghi tiêu đề cột
        xlWorkSheet.Cells(1, 1) = "DVDD"
        For j = 1 To v_slgLUT
            xlWorkSheet.Cells(1, j + 1) = "TN_LUT" & j
        Next
        For i = 0 To v_slgDVDD - 1
            For j = 0 To v_slgLUT ' 
                xlWorkSheet.Cells(i + 2, j + 1) = grdThichNghi(j, i).Value
            Next
        Next
        'Export LUT sang excel
        xlWorkSheet = xlWorkBook.Sheets.Add()
        xlWorkSheet.Name = "LUT"
        ' Ghi tiêu đề cột
        xlWorkSheet.Cells(1, 1) = "LUT"
        xlWorkSheet.Cells(1, 2) = "TEN_LUT"
        xlWorkSheet.Cells(1, 3) = "MOTA"
        For i = 0 To v_slgLUT - 1
            For j = 0 To 2 ' grdLUT có 3 cột
                xlWorkSheet.Cells(i + 2, j + 1) = grdLUT(j, i).Value
            Next
        Next
        'Export LUT_Moi truong sang excel
        xlWorkSheet = xlWorkBook.Sheets.Add()
        xlWorkSheet.Name = "LUT_MT"
        ' Ghi tiêu đề cột
        xlWorkSheet.Cells(1, 1) = "LUT"
        xlWorkSheet.Cells(1, 2) = "CHISO_MT"

        For i = 0 To v_slgLUT - 1
            For j = 0 To 1 ' grdLUT có 3 cột
                xlWorkSheet.Cells(i + 2, j + 1) = grdMoitruong(j, i).Value
            Next
        Next

        'Export LUT_Laodong sang excel
        xlWorkSheet = xlWorkBook.Sheets.Add()
        xlWorkSheet.Name = "LUT_LD"
        ' Ghi tiêu đề cột
        xlWorkSheet.Cells(1, 1) = "LUT"
        xlWorkSheet.Cells(1, 2) = "laodong"

        For i = 0 To v_slgLUT - 1
            For j = 0 To 1 ' grdLUT có 2 cột (LUT, laodong)
                xlWorkSheet.Cells(i + 2, j + 1) = grdLaodong(j, i).Value
            Next
        Next
        ' Export DVDD 
        xlWorkSheet = xlWorkBook.Sheets.Add()
        xlWorkSheet.Name = "DVDD"
        ' Ghi tiêu đề cột
        'For j = 1 To 6
        '    xlWorkSheet.Cells(1, j) = "dvdd_cot" & j
        'Next
        xlWorkSheet.Cells(1, 1) = "DVDD"
        xlWorkSheet.Cells(1, 2) = "DIENTICH"
        xlWorkSheet.Cells(1, 3) = "LOAIDAT"
        xlWorkSheet.Cells(1, 4) = "DOSAUNGAP"
        xlWorkSheet.Cells(1, 5) = "THOIGIANNGAP"
        xlWorkSheet.Cells(1, 6) = "DOSAUTANGPHEN"

        'Ghi dữ liệu của grid vào excel 
        For i = 0 To v_slgDVDD ' Bắt dau tiu 1 vi dong 0 là tiêu đề đã ghi ở trên
            For j = 0 To 5
                xlWorkSheet.Cells(i + 2, j + 1) = grdDVDD(j, i).Value
            Next
        Next
        ' Lưu và đóng excel 
        Dim v_fname As String
        '   Dim kq As Integer
        Dim fopen As New SaveFileDialog

        fopen.FileName = "toiuuhoa_sdd1.xlsx"
        'End Try

        fopen.Filter = "Excel (*.xlsx)|*.xlsx"
        fopen.ShowDialog()
        v_fname = fopen.FileName
        If System.IO.File.Exists(v_fname) = True Then
            Try
                Kill(v_fname)
            Catch
                MsgBox("File đang mở không ghi đè được, xin đóng file excel và thực hiện lại!")
            End Try
        End If
        'txtFile.Text = fopen.FileName
        '_____________
        ' Excel.XlFileFormat.xlWorkbookDefault : Ghi dinh dang mặc định của excel ( xlsx) Nếu muốn xuất excel 97, chọn lại xlWorkbookNormal 
        xlWorkBook.SaveAs(v_fname, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, _
        Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
        xlWorkBook.Close(True, misValue, misValue)
        xlApp.Quit()

        releaseObject(xlWorkSheet)
        releaseObject(xlWorkBook)
        releaseObject(xlApp)
        MessageBox.Show("Đã xuất xong!")
        'Catch
        '    MessageBox.Show("Xảy ra lỗi trong quá trình lưu file excel!")
        'End Try


    End Sub



    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
            MessageBox.Show("Lỗi xảy ra khi đóng excel" + ex.ToString())
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub toolLuu_Click(sender As Object, e As EventArgs) Handles toolLuu.Click
        mnuLuu.PerformClick()
    End Sub

    Private Sub mnuOpenProject_Click(sender As Object, e As EventArgs) Handles mnuOpenProject.Click
        Dim dt_DVDD As New Data.DataTable
        Dim dt_LUT As New Data.DataTable
        Dim dt_Moitruong As New Data.DataTable
        Dim dt_Laodong As New Data.DataTable
        Dim dt_Thichnghi As New Data.DataTable
        Dim dt_loinhuan As New Data.DataTable
        Dim dt_Chiphi As New Data.DataTable
        Dim dt_Rangbuoc As New Data.DataTable
        Dim dt_Thongtin As New Data.DataTable

        'Dim dt_Chung As New Data.DataTable

        Dim v_fname As String = ""
        'Ket noi voi Excel
        Dim con_strXLS As String
        Dim ConnXLS As System.Data.OleDb.OleDbConnection
        Dim objCmdSelect As OleDbCommand
        Dim objAdapterXLS As OleDbDataAdapter = New OleDbDataAdapter()
        ' Đọc file dữ liệu import 
        Dim fopen As New OpenFileDialog

        Dim kq As Integer
        fopen.FileName = ""
        fopen.Filter = "Excel (*.xlsx)|*.xlsx"
        fopen.Multiselect = False
        fopen.Title = "Chọn tập tin cần nạp"
        kq = fopen.ShowDialog()
        v_fname = fopen.FileName
        If kq = vbOK Then
            con_strXLS = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + v_fname + ";Extended Properties=EXCEL 12.0 Xml;"
            ConnXLS = New System.Data.OleDb.OleDbConnection(con_strXLS)
            ConnXLS.Open()
            ' Try

            objCmdSelect = New OleDbCommand("SELECT * FROM [DVDD$]", ConnXLS)
            '_______________________________________________________________________________________________
            ' Import data from sheet [DVDD]
            objAdapterXLS.SelectCommand = objCmdSelect

            objAdapterXLS.SelectCommand.ExecuteNonQuery()
            objAdapterXLS.Fill(dt_DVDD)
            grdDVDD.DataSource = Nothing
            grdDVDD.Rows.Clear()
            grdDVDD.Columns.Clear()
            'grdDVDD.Rows.Clear()
            grdDVDD.DataSource = dt_DVDD

            'Catch

            'End Try
            ' Đọc dữ liệu LUT
            'Try
            objCmdSelect = New OleDbCommand("SELECT * FROM [LUT$]", ConnXLS)
            '_______________________________________________________________________________________________
            ' Import data from sheet [LUT]
            objAdapterXLS.SelectCommand = objCmdSelect
            objAdapterXLS.SelectCommand.ExecuteNonQuery()
            objAdapterXLS.Fill(dt_LUT)
            'grdLUT.Rows.Clear()
            grdLUT.DataSource = Nothing
            grdLUT.Rows.Clear()
            grdLUT.Columns.Clear()
            grdLUT.DataSource = dt_LUT
            'Catch

            'End Try
            ' Đọc dữ liệu chi số môi trường
            'Try
            objCmdSelect = New OleDbCommand("SELECT * FROM [LUT_MT$]", ConnXLS)
            '_______________________________________________________________________________________________
            ' Import data from sheet [LUT]
            objAdapterXLS.SelectCommand = objCmdSelect
            objAdapterXLS.SelectCommand.ExecuteNonQuery()
            objAdapterXLS.Fill(dt_Moitruong)
            'grdLUT.Rows.Clear()
            grdMoitruong.DataSource = Nothing
            grdMoitruong.Rows.Clear()
            grdMoitruong.Columns.Clear()
            grdMoitruong.DataSource = dt_Moitruong
            'Catch

            'End Try
            ' Đọc dữ liệu LUT -  yêu cầu lao động
            'Try
            objCmdSelect = New OleDbCommand("SELECT * FROM [LUT_LD$]", ConnXLS)
            '_______________________________________________________________________________________________
            ' Import data from sheet [LUT]
            objAdapterXLS.SelectCommand = objCmdSelect
            objAdapterXLS.SelectCommand.ExecuteNonQuery()
            objAdapterXLS.Fill(dt_Laodong)
            'grdLUT.Rows.Clear()
            grdLaodong.DataSource = Nothing
            grdLaodong.Rows.Clear()
            grdLaodong.Columns.Clear()
            grdLaodong.DataSource = dt_Laodong
            'Catch

            'End Try
            '' Đọc dữ liệu DVDD_TN
            Try
                objCmdSelect = New OleDbCommand("SELECT * FROM [DVDD_TN$]", ConnXLS)
                '_______________________________________________________________________________________________
                ' Import data from sheet [DVĐ_TN]
                objAdapterXLS.SelectCommand = objCmdSelect

                objAdapterXLS.SelectCommand.ExecuteNonQuery()
                objAdapterXLS.Fill(dt_Thichnghi)
                'grdThichNghi.Rows.Clear()
                'grdThichNghi.Columns.Clear()
                grdThichNghi.DataSource = Nothing
                grdThichNghi.Rows.Clear()
                grdThichNghi.Columns.Clear()
                grdThichNghi.DataSource = dt_Thichnghi

            Catch

            End Try
            '' Đọc dữ liệu DVDD_CP
            Try
                objCmdSelect = New OleDbCommand("SELECT * FROM [DVDD_CP$]", ConnXLS)
                '_______________________________________________________________________________________________
                ' Import data from sheet [DVĐ_CP]
                objAdapterXLS.SelectCommand = objCmdSelect
                'dt_XLS.Clear()
                objAdapterXLS.SelectCommand.ExecuteNonQuery()
                objAdapterXLS.Fill(dt_Chiphi)
                'grdChiphi.Rows.Clear()
                'grdChiphi.Columns.Clear()
                grdChiphi.DataSource = Nothing
                grdChiphi.Rows.Clear()
                grdChiphi.Columns.Clear()
                grdChiphi.DataSource = dt_Chiphi
            Catch

            End Try
            ' Đọc dữ liệu DVDD_LN
            Try
                objCmdSelect = New OleDbCommand("SELECT * FROM [DVDD_LN$]", ConnXLS)
                '_______________________________________________________________________________________________
                ' Import data from sheet [DVĐ_CP]
                objAdapterXLS.SelectCommand = objCmdSelect
                'dt_XLS.Clear()
                objAdapterXLS.SelectCommand.ExecuteNonQuery()
                objAdapterXLS.Fill(dt_loinhuan)
                'grdLoinhuan.Rows.Clear()
                'grdLoinhuan.Columns.Clear()
                grdLoinhuan.DataSource = Nothing
                grdLoinhuan.Rows.Clear()
                grdLoinhuan.Columns.Clear()
                grdLoinhuan.DataSource = dt_loinhuan
            Catch

            End Try
            ' Đọc dữ liệu DIENTICH_LUT
            Try
                objCmdSelect = New OleDbCommand("SELECT * FROM [DIENTICH_LUT$]", ConnXLS)
                '_______________________________________________________________________________________________
                ' Import data from sheet [dientich rang buoc lut]
                objAdapterXLS.SelectCommand = objCmdSelect
                'dt_XLS.Clear()
                objAdapterXLS.SelectCommand.ExecuteNonQuery()
                objAdapterXLS.Fill(dt_Rangbuoc)
                'grdRangbuoc.Rows.Clear()
                'grdRangbuoc.Columns.Clear()
                grdRangbuoc.DataSource = Nothing
                grdRangbuoc.Rows.Clear()
                grdRangbuoc.Columns.Clear()
                grdRangbuoc.DataSource = dt_Rangbuoc
            Catch

            End Try

            ' Đọc thongtinchung 
            Try
                objCmdSelect = New OleDbCommand("SELECT * FROM [THONGTINCHUNG$]", ConnXLS)
                '_______________________________________________________________________________________________
                ' Import data from sheet [dientich rang buoc lut]
                objAdapterXLS.SelectCommand = objCmdSelect
                'dt_XLS.Clear()
                objAdapterXLS.SelectCommand.ExecuteNonQuery()
                objAdapterXLS.Fill(dt_Thongtin)
                'grdRangbuoc.Rows.Clear()
                'grdRangbuoc.Columns.Clear()
                v_slgDVDD = dt_Thongtin.Rows(0)("SLG_DVDD")
                v_slgLUT = dt_Thongtin.Rows(0)("SLG_LUT")
                txtTogngaycong.Text = dt_Thongtin.Rows(0)("SLG_LAODONG")
                txtTongvon.Text = dt_Thongtin.Rows(0)("TONGVON")
                v_fileDVDD = dt_Thongtin.Rows(0)("file_dvdd")
                ' Nạp bản đồ DDVDDD 
                frmNewProject.readShapefile(v_fileDVDD)
            Catch

            End Try
            ConnXLS.Close()
        End If ' kết thúc if file exist 
    End Sub
    Private Sub createGrdKetqua()
        Dim i As Integer
        ' Tạo ra số cột theo số lượng LUT
        'grdKetqua.DataSource = Nothing
        grdKetqua.Rows.Clear()
        grdKetqua.Columns.Clear()
        grdKetqua.ColumnCount = v_slgLUT + 1
        grdKetqua.Columns(0).HeaderText = "Mã ĐVĐĐ"
        For i = 1 To v_slgLUT
            'FrmMain.grdDVDD.RowHeadersBorderStyle
            grdKetqua.Columns(i).HeaderText = "Diện tích LUT" & Trim(Str(i))
        Next
        ' Tạo ra số dòng theo số lượng ĐVĐ
        For i = 0 To v_slgDVDD - 1
            'FrmMain.grdDVDD.RowHeadersBorderStyle
            Dim row As String() = New String() {"DVDD" & Trim(Str(i + 1))}
            grdKetqua.Rows.Add(row)
        Next

    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles rdTonghop.CheckedChanged
        lblHammuctieu.Text = "Hàm mục tiêu:  Z = Sum( [LN(DVDD,LUT) *LD(DVDD,LUT)*MT(DVDD,LUT)] * [X]) -> Max "
    End Sub


    Private Sub rdLaodong_CheckedChanged(sender As Object, e As EventArgs) Handles rdLaodong.CheckedChanged
        lblHammuctieu.Text = "Hàm mục tiêu:  Z = Sum(LD(DVDD,LUT)* [X]) -> Max "
    End Sub

    Private Sub rdLN_MT_CheckedChanged(sender As Object, e As EventArgs) Handles rdLN_MT.CheckedChanged
        lblHammuctieu.Text = "Hàm mục tiêu:  Z = Sum(LN(DVDD,LUT)*MT(DVDD,LUT)*X) -> Max "
    End Sub

    Private Sub rdLoinhuan_CheckedChanged(sender As Object, e As EventArgs) Handles rdLoinhuan.CheckedChanged
        lblHammuctieu.Text = "Hàm mục tiêu:  Z = Sum(LN(DVDD,LUT)*X) -> Max "
    End Sub

    Private Sub mnuReadDVDD_Click(sender As Object, e As EventArgs) Handles mnuReadDVDD.Click
        MsgBox(" Đọc dữ liệu DDVDDD, diện tích từ shapefile. Cần chỉ định cột chưa mã DDVDDD, cột chứa diện tích đất đai")
    End Sub

    Private Sub txtTonglaodong_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)

        Try
            txtTongsonguoi.Text = FormatNumber(txtTongsonguoi.Text, 1, TriState.False, , TriState.True)
        Catch ex As Exception
            MessageBox.Show("Xin vui lòng nhập số", "Thông báo")
            e.Cancel = True
        End Try
    End Sub

    Private Sub txtTongvon_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)

        Try
            txtTongvon.Text = FormatNumber(txtTongvon.Text, 1, TriState.False, , TriState.True)
        Catch ex As Exception
            MessageBox.Show("Xin vui lòng nhập số", "Thông báo")
            e.Cancel = True
        End Try
    End Sub
End Class

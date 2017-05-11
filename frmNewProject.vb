Imports ArcShapeFileDLL
Imports System.IO

Public Class frmNewProject
    Dim v_slgDVDD As Integer
    Dim v_slgLUT As Integer
    Dim MyShape As New ShapeFiles
    Dim g As Graphics ' Declare a variable to hold a Graphics object
    Dim bmap As Bitmap ' Variable for Bitmap to be displayed in (PictureBox) control
    Dim MaxX As Double = 0
    Dim MinX As Double = 0
    Dim MaxY As Double = 0
    Dim MinY As Double = 0
    Dim pbMaxX As Double = 0
    Dim pbMaxY As Double = 0
    Dim XDegPerPixel As Double = 0
    Dim YDegPerPixel As Double = 0
    Dim theDataSet As New DataTable
    Private Sub cmdKhoitao_Click(sender As Object, e As EventArgs) Handles cmdKhoitao.Click
        v_slgDVDD = Val(txtSLgDvdd.Text)
        v_slgLUT = Val(txtSlgLUT.Text)
        If v_slgDVDD > 0 And v_slgLUT > 0 Then
            ' Tao mới các grd trong frmMain để người dùng nhập liệu vào
            ' Gán vào biến toàn cục trong frmMain
            FrmMain.v_slgDVDD = v_slgDVDD
            FrmMain.v_slgLUT = v_slgLUT
            createGrdDVDD()
            createGrdLUT()
            createGrdThichnghi()
            createGrdChiphi()
            createGrdLoinhuan()
            createGrdLaodong()
            createGrdMoitruong()
            createGrdRangbuocDientichLUT()
            'MsgBox("Đã tạo mới project xong, vui lòng nhập liệu vào các trang từ 1 - 7!", MsgBoxStyle.Information, "Thông báo")
            Close()
        Else
            MsgBox("Vui lòng nhập số lượng ĐVĐĐ và số LUT cần tối ưu hóa", MsgBoxStyle.Information, "Thông báo")
        End If

    End Sub
    Private Sub createGrdDVDD()
        Dim i As Integer
        FrmMain.grdDVDD.DataSource = Nothing
        FrmMain.grdDVDD.Rows.Clear()
        FrmMain.grdDVDD.ColumnCount = 1
        FrmMain.grdDVDD.Columns(0).HeaderText = "Mã ĐVĐĐ"
        'FrmMain.grdDVDD.Columns(1).HeaderText = "Diện tích (ha)"
        'FrmMain.grdDVDD.Columns(2).HeaderText = "Loại đất"

        'FrmMain.grdDVDD.Columns(3).HeaderText = "Độ sâu ngập"
        'FrmMain.grdDVDD.Columns(4).HeaderText = "Thời gian ngập"
        'FrmMain.grdDVDD.Columns(5).HeaderText = "Độ sâu tằng phèn"

        
        load_dbf_shp()
        For i = 0 To v_slgDVDD - 1
            'FrmMain.grdDVDD.RowHeadersBorderStyle

            ' Dim row As String() = New String() {"DVDD" & Trim(Str(i + 1))}
            'FrmMain.grdDVDD.Rows.Add(row)
            FrmMain.grdDVDD.Item(0, i).Value = "DVDD" & Trim(Str(i + 1))
        Next
    End Sub

    Private Sub createGrdLUT()
        Dim i As Integer

        FrmMain.grdLUT.DataSource = Nothing
        FrmMain.grdLUT.Rows.Clear()
        FrmMain.grdLUT.ColumnCount = 3
        FrmMain.grdLUT.Columns(0).HeaderText = "Mã LUT"
        FrmMain.grdLUT.Columns(1).HeaderText = "Tên LUT "
        FrmMain.grdLUT.Columns(2).HeaderText = "Mô tả"
        For i = 0 To v_slgLUT - 1
            'FrmMain.grdDVDD.RowHeadersBorderStyle
            Dim row As String() = New String() {"LUT" & Trim(Str(i + 1))}
            FrmMain.grdLUT.Rows.Add(row)
        Next
    End Sub
    Private Sub createGrdMoitruong()
        Dim i As Integer

        FrmMain.grdLUT.DataSource = Nothing
        FrmMain.grdLUT.Rows.Clear()
        FrmMain.grdLUT.ColumnCount = 2
        FrmMain.grdLUT.Columns(0).HeaderText = "Mã LUT"
        FrmMain.grdLUT.Columns(1).HeaderText = "Chỉ số cải thiện môi trường(%)"

        For i = 0 To v_slgLUT - 1
            'FrmMain.grdDVDD.RowHeadersBorderStyle
            Dim row As String() = New String() {"LUT" & Trim(Str(i + 1))}
            FrmMain.grdLUT.Rows.Add(row)
        Next
    End Sub
    Private Sub createGrdThichnghi()
        Dim i As Integer
        ' Tạo ra số cột theo số lượng LUT
        FrmMain.grdThichNghi.DataSource = Nothing
        FrmMain.grdThichNghi.Rows.Clear()
        FrmMain.grdThichNghi.Columns.Clear()
        FrmMain.grdThichNghi.ColumnCount = v_slgLUT + 1
        FrmMain.grdThichNghi.Columns(0).HeaderText = "Mã ĐVĐĐ"
        For i = 1 To v_slgLUT
            'FrmMain.grdDVDD.RowHeadersBorderStyle
            FrmMain.grdThichNghi.Columns(i).HeaderText = "TN LUT" & Trim(Str(i))
        Next
        ' Tạo ra số dòng theo số lượng ĐVĐ
        For i = 0 To v_slgDVDD - 1
            'FrmMain.grdDVDD.RowHeadersBorderStyle
            Dim row As String() = New String() {"DVDD" & Trim(Str(i + 1))}
            FrmMain.grdThichNghi.Rows.Add(row)
        Next

    End Sub
    Private Sub createGrdChiphi()
        Dim i As Integer
        ' Tạo ra số cột theo số lượng LUT
        '_____________
        FrmMain.grdChiphi.DataSource = Nothing
        FrmMain.grdChiphi.Rows.Clear()
        FrmMain.grdChiphi.ColumnCount = 2
        FrmMain.grdChiphi.Columns(0).HeaderText = "Mã LUT"
        FrmMain.grdChiphi.Columns(1).HeaderText = "Chi phí (triệu đồng)"
        For i = 0 To v_slgLUT - 1
            'FrmMain.grdDVDD.RowHeadersBorderStyle
            Dim row As String() = New String() {"LUT" & Trim(Str(i + 1))}
            FrmMain.grdChiphi.Rows.Add(row)
        Next

    End Sub
    Private Sub createGrdLoinhuan()
        Dim i As Integer
        ' Tạo ra số cột theo số lượng LUT
        FrmMain.grdLoinhuan.DataSource = Nothing
        FrmMain.grdLoinhuan.Rows.Clear()
        FrmMain.grdLoinhuan.Columns.Clear()
        FrmMain.grdLoinhuan.ColumnCount = v_slgLUT + 1
        FrmMain.grdLoinhuan.Columns(0).HeaderText = "Mã ĐVĐĐ"
        For i = 1 To v_slgLUT
            'FrmMain.grdDVDD.RowHeadersBorderStyle
            FrmMain.grdLoinhuan.Columns(i).HeaderText = "Lợi nhuận LUT" & Trim(Str(i))
        Next
        ' Tạo ra số dòng theo số lượng ĐVĐ
        For i = 0 To v_slgDVDD - 1
            'FrmMain.grdDVDD.RowHeadersBorderStyle
            Dim row As String() = New String() {"DVDD" & Trim(Str(i + 1))}
            FrmMain.grdLoinhuan.Rows.Add(row)
        Next
    End Sub
    Private Sub createGrdLaodong()
        Dim i As Integer
     
        '_____________
        FrmMain.grdLaodong.DataSource = Nothing
        FrmMain.grdLaodong.Rows.Clear()
        FrmMain.grdLaodong.ColumnCount = 2
        FrmMain.grdLaodong.Columns(0).HeaderText = "Mã LUT"
        FrmMain.grdLaodong.Columns(1).HeaderText = "Lao động (ngày)"
        For i = 0 To v_slgLUT - 1
            'FrmMain.grdDVDD.RowHeadersBorderStyle
            Dim row As String() = New String() {"LUT" & Trim(Str(i + 1))}
            FrmMain.grdChiphi.Rows.Add(row)
        Next

    End Sub
    Private Sub createGrdRangbuocDientichLUT()
        Dim i As Integer
        ' Tạo ra số cột theo số lượng LUT
        FrmMain.grdRangbuoc.DataSource = Nothing
        FrmMain.grdRangbuoc.Rows.Clear()
        'FrmMain.grdRangbuoc.Columns.Clear()

        FrmMain.grdRangbuoc.ColumnCount = 2
        FrmMain.grdRangbuoc.Columns(0).HeaderText = "Kiểu sử dụng (LUT)"
        FrmMain.grdRangbuoc.Columns(1).HeaderText = "Diện tích ràng buộc (ha)"

        ' Tạo ra số dòng theo số lượng ĐVĐ
        For i = 0 To v_slgLUT - 1
            'FrmMain.grdDVDD.RowHeadersBorderStyle
            Dim row As String() = New String() {"LUT" & Trim(Str(i + 1))}
            FrmMain.grdRangbuoc.Rows.Add(row)
        Next
    End Sub

    Private Sub cboBrowseDVDD_Click(sender As Object, e As EventArgs) Handles btnBrowseDVDD.Click
        Dim v_fname As String
        '   Dim kq As Integer
        Dim fopen As New OpenFileDialog

        fopen.FileName = "dvdd.shp"
        'End Try

        fopen.Filter = "Shapefile (*.shp)|*.shp"
        fopen.ShowDialog()
        v_fname = fopen.FileName

        txtFileDVDD.Text = fopen.FileName
        readShapefile(v_fname)
        FrmMain.v_fileDVDD = v_fname
    End Sub

    Private Sub cmdThoat_Click(sender As Object, e As EventArgs) Handles cmdThoat.Click
        Close()

    End Sub

    Private Sub btnBrowseProject_Click(sender As Object, e As EventArgs) Handles btnBrowseProject.Click
        Dim v_fname As String
        '   Dim kq As Integer
        Dim fopen As New SaveFileDialog

        fopen.FileName = "Toiuuhoa_proj1.xlsx"
        'End Try

        fopen.Filter = "Excel (*.xlsx)|*.xlsx"
        fopen.ShowDialog()
        v_fname = fopen.FileName
        If System.IO.File.Exists(v_fname) = True Then
            Kill(v_fname)
        End If
        txtFile_project.Text = fopen.FileName
    End Sub
    Public Sub readShapefile(v_fname As String)
        Dim arLat As New ArrayList
        Dim arLon As New ArrayList
        'Dim ThisPart As Integer
        'Dim VertCount As Integer
        Dim Record As Integer = 0
        Dim Fin As String = ""
        Dim X As Double = 0
        Dim Y As Double = 0
        Dim pt As Integer = 0
        'Dim Coord As Integer
        Dim Lon As Double = 0
        Dim Lat As Double = 0
        Dim StartPoint As New Point
        Dim EndPoint As New Point
        Dim LinePen As New Pen(Color.Red, 1)
        Dim shpOpen As ShapeFiles.eNew

        'init picturebox
        FrmMain.PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
        g = GetGraphics()

        Fin = v_fname '"F:\shptest\lopxa_region.shp"
        MyShape.ReadDataOnMove = True
        ' ListBox1.Items.Clear()

        If File.Exists(Fin) Then
            MyShape.OpenShape(Fin, shpOpen)
            txtSLgDvdd.Text = MyShape.RecordCount
        End If
        'ListBox1.Items.Add("Number of Records: " & MyShape.RecordCount)
        'ListBox1.Items.Add(MyShape.xMin & vbTab & MyShape.xMax)
        'ListBox1.Items.Add(MyShape.yMin & vbTab & MyShape.yMax)

        ' set picturebox bounds
        MinX = MyShape.xMin - 10
        MaxX = MyShape.xMax + 10
        MinY = MyShape.yMin - 10
        MaxY = MyShape.yMax + 10

        pbMaxX = FrmMain.PictureBox1.Width
        pbMaxY = FrmMain.PictureBox1.Height
        XDegPerPixel = Math.Abs(MaxX - MinX) / pbMaxX
        YDegPerPixel = Math.Abs(MaxY - MinY) / pbMaxY

        With MyShape
            For Record = 0 To MyShape.RecordCount - 1
                For ThisPart = 1 To .Parts.Count
                    For VertCount = .Parts(ThisPart).Begins To .Parts(ThisPart).Ends
                        arLon.Add(.Vertices(VertCount).X_Cord)
                        arLat.Add(.Vertices(VertCount).Y_Cord)
                    Next VertCount

                    'using ArrayList, integrate vertices into picture box
                    pt = 0
                    For Coord = 0 To arLat.Count - 2
                        'For clarity
                        '            Lon = CType(arLon(pt), Double)
                        '            Lat = CType(arLat(pt), Double)
                        '            X = Math.Abs(Lon - MinX) / XDegPerPixel
                        '            Y = Math.Abs(MaxY - Lat) / YDegPerPixel
                        'For optimization
                        X = Math.Abs(CType(arLon(pt), Double) - MinX) / XDegPerPixel
                        Y = Math.Abs(MaxY - CType(arLat(pt), Double)) / YDegPerPixel
                        StartPoint = New Point(CType(X, Integer), CType(Y, Integer))

                        'For clarity
                        '            Lon = CType(arLon(pt + 1), Double)
                        '            Lat = CType(arLat(pt + 1), Double)
                        '            X = Math.Abs(Lon - MinX) / XDegPerPixel
                        '            Y = Math.Abs(MaxY - Lat) / YDegPerPixel
                        'For optimization
                        X = Math.Abs(CType(arLon(pt + 1), Double) - MinX) / XDegPerPixel
                        Y = Math.Abs(MaxY - CType(arLat(pt + 1), Double)) / YDegPerPixel
                        EndPoint = New Point(CType(X, Integer), CType(Y, Integer))

                        g.DrawLine(LinePen, StartPoint, EndPoint)
                        pt += 1
                    Next Coord
                    'clear ArrayList for next record
                    arLat.Clear()
                    arLon.Clear()

                Next ThisPart
                MyShape.MoveNext()

            Next Record

        End With
        'draw shape file
        FrmMain.PictureBox1.Image = bmap
        g.Dispose()
        'End If
    End Sub
    Private Function GetGraphics() As Graphics
        ' Make bmap the same size and resolution as the PictureBox
        bmap = New Bitmap(FrmMain.PictureBox1.Width, FrmMain.PictureBox1.Height, FrmMain.PictureBox1.CreateGraphics)
        ' Assign the Bitmap object to the Graphics object
        ' and return it
        Return Graphics.FromImage(bmap)
    End Function
    Private Sub load_dbf_shp()
        ' Test load attribute data
        Dim cnn As New System.Data.OleDb.OleDbConnection
        Dim da As New System.Data.OleDb.OleDbDataAdapter

        Dim filePath As String = txtFileDVDD.Text
        Dim directory As String = Path.GetDirectoryName(filePath)
        Dim split As String() = filePath.Split("\")
        Dim parentFolder As String = split(split.Length - 2)
        Dim fname As String = Path.GetFileNameWithoutExtension(filePath) & ".dbf"
        '        MsgBox("dir:" & directory & "; db file name:" & filePath & "; folder:" & parentFolder)
        cnn.ConnectionString = "Provider=VFPOLEDB;Data Source=" & directory & ";Exclusive=Yes;Collating Sequence=machine"
        Try
            cnn.Open()
            da.SelectCommand = New System.Data.OleDb.OleDbCommand("select * from " & fname, cnn)
            da.Fill(theDataSet)
            FrmMain.grdDVDD.DataSource = theDataSet
            FrmMain.grdDVDD.Refresh()
        Catch ex As Exception
            MsgBox("Lỗi đọc file thuộc tính." & vbNewLine & ex.Message & vbNewLine & ex.ToString)
        End Try
    End Sub
End Class
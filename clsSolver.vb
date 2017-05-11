Option Strict Off
Option Explicit On

Class clsSolver

    ' This demo program expects that the lpsolve dll is in the same directory as the project or in a directory of the path.
    ' Note that the lpsolve dll is not a COM object, so don't try to reference it, that will not work.

    ' The VB interface to version 5 is different than from version 4. This to make it more 'object oriented'
    ' The definition is no longer in a bas module, but in a class. Each function must be accessed via the class.

    Public Sub Main()
        Dim a As Integer

        System.Diagnostics.Debug.WriteLine(System.Runtime.InteropServices.Marshal.SizeOf(a))

        System.Diagnostics.Debug.WriteLine(CurDir())
        lpsolve55.Init(".")
        '   System.Diagnostics.Debug.WriteLine("bat dau phan toi uu")
        Test()

    End Sub

    Private Sub logfunc(ByVal lp As Integer, ByVal userhandle As Integer, ByVal Buf As String)

        System.Diagnostics.Debug.Write(Buf)

    End Sub

    Private Function ctrlcfunc(ByVal lp As Integer, ByVal userhandle As Integer) As Integer

        'If set to True, then solve is aborted and returncode will indicate this.
        'ctrlcfunc = True

    End Function

    Private Sub msgfunc(ByVal lp As Integer, ByVal userhandle As Integer, ByVal message As lpsolve55.lpsolve_msgmask)

        'System.Diagnostics.Debug.WriteLine(message)

    End Sub

    Public Sub Test()
        Dim lp As Integer
        Dim release, Major, Minor, build As Integer
        Dim row(0) As Double
        Dim lower() As Double
        Dim upper() As Double
        Dim Col() As Double
        Dim Arry() As Double

        'lp = lpsolve55.make_lp(0, 4)

        'lpsolve55.version(Major, Minor, release, build)

        ''let's first demonstrate the logfunc callback feature
        ''completely optional of course
        'lpsolve55.put_logfunc(lp, AddressOf logfunc, 0)
        'lpsolve55.print_str(lp, "lp_solve " & Major & "." & Minor & "." & release & "." & build & " demo" & vbLf & vbLf)
        'lpsolve55.solve(lp) 'just to see that a message is send via the logfunc routine ...
        ''ok, that is enough, no more callback
        'lpsolve55.put_logfunc(lp, Nothing, 0)

        ''Now redirect all output to a file
        'lpsolve55.set_outputfile(lp, CurDir() & "\result.txt")

        ''set an abort function. Again optional
        'lpsolve55.put_abortfunc(lp, AddressOf ctrlcfunc, 0)

        ''set a message function. Again optional
        'lpsolve55.put_msgfunc(lp, AddressOf msgfunc, 0, lpsolve55.lpsolve_msgmask.MSG_PRESOLVE + lpsolve55.lpsolve_msgmask.MSG_LPFEASIBLE + lpsolve55.lpsolve_msgmask.MSG_LPOPTIMAL + lpsolve55.lpsolve_msgmask.MSG_MILPEQUAL + lpsolve55.lpsolve_msgmask.MSG_MILPFEASIBLE + lpsolve55.lpsolve_msgmask.MSG_MILPBETTER)

        'lpsolve55.print_str(lp, "lp_solve " & Major & "." & Minor & "." & release & "." & build & " demo" & vbLf & vbLf)
        'lpsolve55.print_str(lp, "This demo will show most of the features of lp_solve " & Major & "." & Minor & "." & release & "." & build & vbLf)

        'lpsolve55.print_str(lp, vbLf & "We start by creating a new problem with 4 variables and 0 constraints" & vbLf)
        'lpsolve55.print_str(lp, "We use: lp = lpsolve55.make_lp(0, 4)" & vbLf)

        'lpsolve55.set_timeout(lp, 0)

        'lpsolve55.print_str(lp, "We can show the current problem with lpsolve55.print_lp(lp)" & vbLf)
        'lpsolve55.print_lp(lp)

        'lpsolve55.print_str(lp, "Now we add some constraints" & vbLf)
        'lpsolve55.print_str(lp, "lpsolve55.add_constraint(lp, New Double() {0, 3, 2, 2, 1}, lpsolve55.lpsolve_constr_types.LE, 4)" & vbLf)
        'lpsolve55.add_constraint(lp, New Double() {0, 3, 2, 2, 1}, lpsolve55.lpsolve_constr_types.LE, 4)
        'lpsolve55.print_lp(lp)

        'lpsolve55.print_str(lp, "lpsolve55.add_constraint(lp, New Double() {0, 0, 4, 3, 1}, lpsolve55.lpsolve_constr_types.GE, 3)" & vbLf)
        'lpsolve55.add_constraint(lp, New Double() {0, 0, 4, 3, 1}, lpsolve55.lpsolve_constr_types.GE, 3)
        'lpsolve55.print_lp(lp)
        '' Hàm m?c tiêu
        'lpsolve55.print_str(lp, "Set the objective function" & vbLf)
        'lpsolve55.print_str(lp, "lpsolve55.set_obj_fn(lp, New Double() {0, 2, 3, -2, 3})" & vbLf)
        'lpsolve55.set_obj_fn(lp, New Double() {0, 2, 3, -2, 3})
        'lpsolve55.print_lp(lp)

        'lpsolve55.print_str(lp, "Now solve the problem with lpsolve55.print_str(lp), solve(lp)" & vbLf)
        'lpsolve55.print_str(lp, lpsolve55.solve(lp) & ": " & lpsolve55.get_objective(lp) & vbLf)

        'ReDim Col(lpsolve55.get_Ncolumns(lp))
        'lpsolve55.get_variables(lp, Col)

        'ReDim row(lpsolve55.get_Nrows(lp))
        'lpsolve55.get_constraints(lp, row)

        'ReDim Arry(lpsolve55.get_Ncolumns(lp) + lpsolve55.get_Nrows(lp))
        'lpsolve55.get_dual_solution(lp, Arry)

        'ReDim Arry(lpsolve55.get_Ncolumns(lp) + lpsolve55.get_Nrows(lp))
        'ReDim lower(lpsolve55.get_Ncolumns(lp) + lpsolve55.get_Nrows(lp))
        'ReDim upper(lpsolve55.get_Ncolumns(lp) + lpsolve55.get_Nrows(lp))
        'lpsolve55.get_sensitivity_rhs(lp, Arry, lower, upper)

        'ReDim lower(lpsolve55.get_Ncolumns(lp))
        'ReDim upper(lpsolve55.get_Ncolumns(lp))
        'lpsolve55.get_sensitivity_obj(lp, lower, upper)

        'lpsolve55.print_str(lp, "The value is 0, this means we found an optimal solution" & vbLf)
        'lpsolve55.print_str(lp, "We can display this solution with lpsolve55.print_objective(lp) and lpsolve55.print_solution(lp)" & vbLf)
        'lpsolve55.print_objective(lp)
        'lpsolve55.print_solution(lp, 1)
        'lpsolve55.print_constraints(lp, 1)

        'lpsolve55.print_str(lp, "The dual variables of the solution are printed with" & vbLf)
        'lpsolve55.print_str(lp, "lpsolve55.print_duals(lp)" & vbLf)
        'lpsolve55.print_duals(lp)

        'lpsolve55.print_str(lp, "We can change a single element in the matrix with" & vbLf)
        'lpsolve55.print_str(lp, "lpsolve55.set_mat(lp, 2, 1, 0.5)" & vbLf)
        'lpsolve55.set_mat(lp, 2, 1, 0.5)
        'lpsolve55.print_lp(lp)

        'lpsolve55.print_str(lp, "If we want to maximize the objective function use lpsolve55.set_maxim(lp)" & vbLf)
        'lpsolve55.set_maxim(lp)
        'lpsolve55.print_lp(lp)

        'lpsolve55.print_str(lp, "after solving this gives us:" & vbLf)
        'lpsolve55.solve(lp)
        'lpsolve55.print_objective(lp)
        'lpsolve55.print_solution(lp, 1)
        'lpsolve55.print_constraints(lp, 1)
        'lpsolve55.print_duals(lp)

        'lpsolve55.print_str(lp, "Change the value of a rhs element with lpsolve55.set_rh(lp, 1, 7.45)" & vbLf)
        'lpsolve55.set_rh(lp, 1, 7.45)
        'lpsolve55.print_lp(lp)
        'lpsolve55.solve(lp)
        'lpsolve55.print_objective(lp)
        'lpsolve55.print_solution(lp, 1)
        'lpsolve55.print_constraints(lp, 1)

        'lpsolve55.print_str(lp, "We change C4 to the integer type with" & vbLf)
        'lpsolve55.print_str(lp, "lpsolve55.set_int(lp, 4, True)" & vbLf)
        'lpsolve55.set_int(lp, 4, True)
        'lpsolve55.print_lp(lp)

        'lpsolve55.print_str(lp, "We set branch & bound debugging on with lpsolve55.set_debug(lp, 1)" & vbLf)

        'lpsolve55.set_debug(lp, 1)
        'lpsolve55.print_str(lp, "and solve..." & vbLf)

        'lpsolve55.solve(lp)
        'lpsolve55.print_objective(lp)
        'lpsolve55.print_solution(lp, 1)
        'lpsolve55.print_constraints(lp, 1)

        'lpsolve55.print_str(lp, "We can set bounds on the variables with" & vbLf)
        'lpsolve55.print_str(lp, "lpsolve55.set_lowbo(lp, 2, 2) & lpsolve55.set_upbo(lp, 4, 5.3)" & vbLf)
        'lpsolve55.set_lowbo(lp, 2, 2)
        'lpsolve55.set_upbo(lp, 4, 5.3)
        'lpsolve55.print_lp(lp)

        'lpsolve55.solve(lp)
        'lpsolve55.print_objective(lp)
        'lpsolve55.print_solution(lp, 1)
        'lpsolve55.print_constraints(lp, 1)

        'lpsolve55.print_str(lp, "Now remove a constraint with lpsolve55.del_constraint(lp, 1)" & vbLf)
        'lpsolve55.del_constraint(lp, 1)
        'lpsolve55.print_lp(lp)
        'lpsolve55.print_str(lp, "Add an equality constraint" & vbLf)
        'lpsolve55.add_constraint(lp, New Double() {0, 1, 2, 1, 4}, lpsolve55.lpsolve_constr_types.EQ, 8)
        'lpsolve55.print_lp(lp)

        'lpsolve55.print_str(lp, "A column can be added with:" & vbLf)
        'lpsolve55.print_str(lp, "lpsolve55.add_column(lp, New Double() {3, 2, 2})" & vbLf)
        'lpsolve55.add_column(lp, New Double() {3, 2, 2})
        'lpsolve55.print_lp(lp)

        'lpsolve55.print_str(lp, "A column can be removed with:" & vbLf)
        'lpsolve55.print_str(lp, "lpsolve55.del_column(lp, 3)" & vbLf)
        'lpsolve55.del_column(lp, 3)
        'lpsolve55.print_lp(lp)

        'lpsolve55.print_str(lp, "We can use automatic scaling with:" & vbLf)
        'lpsolve55.print_str(lp, "lpsolve55.set_scaling(lp, SCALE_MEAN)" & vbLf)
        'lpsolve55.set_scaling(lp, lpsolve55.lpsolve_scales.SCALE_MEAN)
        'lpsolve55.print_lp(lp)

        'lpsolve55.print_str(lp, "The function lpsolve55.get_mat(lp, row, column) returns a single" & vbLf)
        'lpsolve55.print_str(lp, "matrix element" & vbLf)
        'lpsolve55.print_str(lp, "lpsolve55.get_mat(lp, 2, 3), lpsolve55.get_mat(lp, 1, 1) gives " & lpsolve55.get_mat(lp, 2, 3) & ", " & lpsolve55.get_mat(lp, 1, 1) & vbLf)
        'lpsolve55.print_str(lp, "Notice that get_mat returns the value of the original unscaled problem" & vbLf)

        'lpsolve55.print_str(lp, "If there are any integer type variables, then only the rows are scaled" & vbLf)
        'lpsolve55.print_str(lp, "lpsolve55.set_int(lp, 3, False)" & vbLf)
        'lpsolve55.set_int(lp, 3, False)
        'lpsolve55.print_lp(lp)

        'lpsolve55.solve(lp)
        'lpsolve55.print_str(lp, "lpsolve55.print_objective, lpsolve55.print_solution gives the solution to the original problem" & vbLf)
        'lpsolve55.print_objective(lp)
        'lpsolve55.print_solution(lp, 1)
        'lpsolve55.print_constraints(lp, 1)

        'lpsolve55.print_str(lp, "Scaling is turned off with lpsolve55.unscale(lp)" & vbLf)
        'lpsolve55.unscale(lp)
        'lpsolve55.print_lp(lp)

        'lpsolve55.print_str(lp, "Now turn B&B debugging off and simplex tracing on with" & vbLf)
        'lpsolve55.print_str(lp, "lpsolve55.set_debug(lp, False), lpsolve55.set_trace(lp, True) and lpsolve55.solve(lp)" & vbLf)
        'lpsolve55.set_debug(lp, False)
        'lpsolve55.set_trace(lp, True)

        'lpsolve55.solve(lp)
        'lpsolve55.print_str(lp, "Where possible, lp_solve will start at the last found basis" & vbLf)
        'lpsolve55.print_str(lp, "We can reset the problem to the initial basis with" & vbLf)
        'lpsolve55.print_str(lp, "lpsolve55.default_basis(lp). Now solve it again..." & vbLf)

        'lpsolve55.default_basis(lp)
        'lpsolve55.solve(lp)

        'lpsolve55.print_str(lp, "It is possible to give variables and constraints names" & vbLf)
        'lpsolve55.print_str(lp, "lpsolve55.set_row_name(lp, 1, ""speed"") & set_col_name(lp, 2, ""money"")" & vbLf)
        'lpsolve55.set_row_name(lp, 1, "speed")
        'lpsolve55.set_col_name(lp, 2, "money")
        'lpsolve55.print_lp(lp)
        'lpsolve55.print_str(lp, "As you can see, all column and rows are assigned default names" & vbLf)
        'lpsolve55.print_str(lp, "If a column or constraint is deleted, the names shift place also:" & vbLf)

        'lpsolve55.print_str(lp, "lpsolve55.del_column(lp, 1)" & vbLf)
        'lpsolve55.del_column(lp, 1)
        'lpsolve55.print_lp(lp)

        'lpsolve55.write_lp(lp, CurDir() & "\lp.lp")
        'lpsolve55.write_mps(lp, CurDir() & "\lp.mps")

        'lpsolve55.set_outputfile(lp, vbNullString)

        'lpsolve55.delete_lp(lp)

        'Read a model from an lp structure

        lp = lpsolve55.read_LP(CurDir() & "\lp.lp", False, "test")
        If lp = 0 Then
            MsgBox("Can't find lp.lp, stopping")
            Exit Sub
        End If

        lpsolve55.set_outputfile(lp, CurDir() & "\result2.txt")

        lpsolve55.print_str(lp, "An lp structure can be created and read from a .lp file" & vbLf)
        lpsolve55.print_str(lp, "lp = lpsolve55.read_LP(""lp.lp"", False, ""test"")" & vbLf)
        lpsolve55.print_str(lp, "The verbose option is disabled" & vbLf)

        lpsolve55.print_str(lp, "lp is now:" & vbLf)
        lpsolve55.print_lp(lp)

        lpsolve55.print_str(lp, "solution:" & vbLf)
        lpsolve55.set_debug(lp, 1)
        lpsolve55.solve(lp)
        lpsolve55.set_debug(lp, 0)
        lpsolve55.print_objective(lp)
        lpsolve55.print_solution(lp, 1)
        Dim kq As Double = lpsolve55.get_objective(lp)
        MsgBox("Ham muc tieu :" & kq)
        lpsolve55.print_constraints(lp, 1)
        'Dim row1(5) As Double
        'Dim row2(5) As Integer
        'Dim kq1 As Double = lpsolve55.get_constr_value(lp, 0, 1, row1, row2)
        'MsgBox("Biến:" & kq1)

        ' Bổ sung thêm
        Dim v_constraint(20) As Double
        'Dim row2(5) As Integer
        'Dim kq1 As Double = lpsolve55.get_constraints(lp, v_constraint)
        Dim kq1 As Double = lpsolve55.get_variables(lp, v_constraint)  ' In các biến kết quả
        Dim st As String = ""
        For i = 0 To 20
            st = st & ";" & v_constraint(i)
        Next
        MsgBox("Số lượng ràng buộc:" & st)
        'kq1 = lpsolve55.get_variables(lp, v_constraint)
        'kq1 = lpsolve55.get(lp, v_constraint)


        ' Kết thúc bổ sung
        lpsolve55.write_lp(lp, CurDir() & "\lp.lp")
        lpsolve55.write_mps(lp, CurDir() & "\lp.mps")

        lpsolve55.set_outputfile(lp, vbNullString)
        lpsolve55.delete_lp(lp)

    End Sub
    Public Sub LUOptimizer()
        Dim lp As Integer
        'Read a model from an lp structure
        Dim v_file As String = CurDir() & "\hephuongtrinh.lp" ' hephuongtrinh.lp"
        MsgBox(v_file)
        lp = lpsolve55.read_LP(v_file, False, "test")
        If lp = 0 Then
            MsgBox("Can't find hephuongtrinh.lp, stopping")
            Exit Sub
        End If

        lpsolve55.set_outputfile(lp, CurDir() & "\ketquatoiuu.txt")

        lpsolve55.print_str(lp, "An lp structure can be created and read from a .lp file" & vbLf)
        lpsolve55.print_str(lp, "lp = lpsolve55.read_LP(""lp.lp"", False, ""test"")" & vbLf)
        lpsolve55.print_str(lp, "The verbose option is disabled" & vbLf)

        lpsolve55.print_str(lp, "lp is now:" & vbLf)
        lpsolve55.print_lp(lp)

        lpsolve55.print_str(lp, "solution:" & vbLf)
        lpsolve55.set_debug(lp, 1)
        lpsolve55.solve(lp)
        lpsolve55.set_debug(lp, 0)
        lpsolve55.print_objective(lp)
        lpsolve55.print_solution(lp, 1)
        Dim kq As Double = lpsolve55.get_objective(lp)
        '  MsgBox("Ham muc tieu :" & kq)
        FrmMain.txtTongLN.Text = String.Format("{0:n2}", kq)

        lpsolve55.print_constraints(lp, 1)

        ' Bổ sung thêmdim i á
        Dim i1 As Integer
        Dim j1 As Integer
        Dim k1 As Integer
        Dim v_variables() As Double
        ReDim v_variables(FrmMain.v_slgDVDD * FrmMain.v_slgLUT)
        'Dim row2(5) As Integer
        'Dim kq1 As Double = lpsolve55.get_constraints(lp, v_constraint)
        Dim kq1 As Double = lpsolve55.get_variables(lp, v_variables)
        Dim st As String = ""
        For i = 0 To FrmMain.v_slgDVDD * FrmMain.v_slgLUT - 1
            st = st & v_variables(i) & ";"
        Next
        ' MsgBox("Giá trị các biến:" & st)
        i1 = 1 ' cột bắt đầu từ 1, cột đầu là tên ĐVDD
        j1 = 0
        For k1 = 0 To FrmMain.v_slgDVDD * FrmMain.v_slgLUT - 1
            FrmMain.grdKetqua.Item(i1, j1).Value = v_variables(k1)
            If i1 > FrmMain.v_slgLUT - 1 Then  ' cột tăng dần, nếu cột >số LUT -1 thì xuống dòng 
                i1 = 1 '' Về đầu dòng
                j1 = j1 + 1 ' xuống dòng mới
            Else
                i1 = i1 + 1
            End If

        Next
        ' Kết thúc bổ sung

        lpsolve55.set_outputfile(lp, vbNullString)
        lpsolve55.delete_lp(lp)

    End Sub

End Class
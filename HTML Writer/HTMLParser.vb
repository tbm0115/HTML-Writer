Public Class HTMLParser

    ''' <summary>
    ''' Represents a series of HTML Table parsing methods.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class pTable
        ''' <summary>
        ''' Returns a basic DataTable. Column headers are based on the HTML table header tags.
        ''' </summary>
        ''' <param name="Markup">Raw HTML table markup</param>
        ''' <returns>DataTable</returns>
        ''' <remarks></remarks>
        Public Function Convert_Table_DataTable(ByVal Markup As String) As DataTable
            If Not Markup.ToLower.Contains("<table") And Not Markup.ToLower.Contains("<tbody") Then
                Throw New ApplicationException("Provided markup does not begin with the <table/> or <tbody/> tag!")
            End If
            If Not Markup.ToLower.Contains("<th") Then
                Throw New ApplicationException("Provided markup does not contain proper <th> tag(s)!")
            End If
            Dim ds As New DataTable
            Dim hrws As HTMLWriter.HTMLTable.HTMLTableRow() = Get_TableRows(Markup)
            Dim cntCol As Integer = 0
            If Not IsNothing(hrws) Then
                If hrws(0).TableRow.ToLower.Contains("<th") And hrws(0).TableRow.ToLower.Contains("</th>") Then
                    For Each col As String In Get_RowColumns(hrws(0))
                        ds.Columns.Add(col)
                        cntCol += 1
                    Next
                    If cntCol > 0 Then
                        For i = 1 To hrws.Length - 1 Step 1
                            ds.Rows.Add(ds.NewRow())
                            cntCol = 0
                            For Each col As String In Get_RowColumns(hrws(i))
                                ds.Rows(ds.Rows.Count - 1).Item(cntCol) = col
                                cntCol += 1
                            Next
                        Next
                    End If
                End If
            End If
            Return ds
        End Function
        ''' <summary>
        ''' Returns a basic format XML Document. Each row is labeled based on its index and each child element is labeled based 
        ''' on its column header
        ''' </summary>
        ''' <param name="Markup">Raw HTML table markup</param>
        ''' <returns>XML.XMLDocument</returns>
        ''' <remarks></remarks>
        Public Function Convert_Table_XML(ByVal Markup As String) As Xml.XmlDocument
            If Not Markup.ToLower.Contains("<table") And Not Markup.ToLower.Contains("<tbody") Then
                Throw New ApplicationException("Provided markup does not begin with the <table/> or <tbody/> tag!")
            End If
            If Not Markup.ToLower.Contains("<th") Then
                Throw New ApplicationException("Provided markup does not contain proper <th> tag(s)!")
            End If
            Dim ds As New Xml.XmlDocument
            Dim dc, dr As Xml.XmlElement
            Dim ch() As String
            Dim hrws As HTMLWriter.HTMLTable.HTMLTableRow() = Get_TableRows(Markup)
            Dim cntCol As Integer = 0
            If Not IsNothing(hrws) Then
                If hrws(0).TableRow.ToLower.Contains("<th") And hrws(0).TableRow.ToLower.Contains("</th>") Then
                    For Each col As String In Get_RowColumns(hrws(0))
                        If Not IsNothing(ch) Then
                            ReDim Preserve ch(ch.Length)
                        Else
                            ReDim ch(0)
                        End If
                        ch(ch.Length - 1) = col
                        cntCol += 1
                    Next
                    If cntCol > 0 Then
                        For i = 1 To hrws.Length - 1 Step 1
                            cntCol = 0
                            dr = ds.CreateElement("row" & i.ToString)
                            For Each col As String In Get_RowColumns(hrws(i))
                                dc = ds.CreateElement(ch(cntCol))
                                dc.InnerText = col
                                dr.AppendChild(dc)
                                cntCol += 1
                            Next
                            ds.AppendChild(dr)
                        Next
                    End If
                End If
            End If
            Return ds
        End Function
        ''' <summary>
        ''' Returns an array of HTML Table Rows.
        ''' </summary>
        ''' <param name="Markup">Raw HTML table markup.</param>
        ''' <returns>HTMLWriter.HTMLTable.HTMLTableRow(s)</returns>
        ''' <remarks></remarks>
        Public Function Get_TableRows(ByVal Markup As String) As HTMLWriter.HTMLTable.HTMLTableRow()
            Dim stemp As String = Markup
            Dim rows() As HTMLWriter.HTMLTable.HTMLTableRow
            Do Until stemp = ""
                If stemp.ToLower.Contains("</tr>") Then
                    stemp = stemp.ToLower.Remove(0, stemp.IndexOf("<tr"))
                    If Not IsNothing(rows) Then
                        ReDim Preserve rows(rows.Length)
                    Else
                        ReDim rows(0)
                    End If
                    rows(rows.Length - 1) = New HTMLWriter.HTMLTable.HTMLTableRow()
                    rows(rows.Length - 1).TableRow = stemp.Remove(stemp.ToLower.IndexOf("</tr>") + 5)
                    stemp = stemp.Remove(0, stemp.ToLower.IndexOf("</tr>") + 5)
                Else
                    stemp = ""
                End If
            Loop
            Return rows
        End Function

        ''' <summary>
        ''' Returns an array of strings, each containing cell contents of the provided HTML Table Row.
        ''' </summary>
        ''' <param name="Row">HTMLWriter.HTMLTable.HTMLTableRow Object</param>
        ''' <returns>String Array</returns>
        ''' <remarks></remarks>
        Public Function Get_RowColumns(ByVal Row As HTMLWriter.HTMLTable.HTMLTableRow) As String()
            Dim stemp As String = Row.TableRow
            Dim coltype As String
            Dim cols As String()
            Dim i As Integer
            If stemp.ToLower.Contains("<th") And stemp.ToLower.Contains("</th>") Then
                If stemp.ToLower.Contains("<td") And stemp.ToLower.Contains("</td>") Then
                    Throw New ApplicationException("Provided table contains both table headers and table cells. This should not happen.")
                End If
                coltype = "th"
            ElseIf stemp.ToLower.Contains("<td") And stemp.ToLower.Contains("</td>") Then
                coltype = "td"
            Else
                Throw New ApplicationException("Undetermined column type in Get_RowColumns.")
            End If
            'Get column names
            Do Until stemp = ""
                If stemp.ToLower.Contains("</" & coltype & ">") Then
                    stemp = stemp.ToLower.Remove(0, stemp.IndexOf("<" & coltype))
                    i = stemp.ToLower.IndexOf(">")
                    If Not IsNothing(cols) Then
                        ReDim Preserve cols(cols.Length)
                    Else
                        ReDim cols(0)
                    End If
                    cols(cols.Length - 1) = stemp.Remove(stemp.ToLower.IndexOf("</" & coltype & ">")).Remove(0, i + 1)
                    If cols(cols.Length - 1).ToLower.Contains(vbLf) Then
                        cols(cols.Length - 1) = cols(cols.Length - 1).Replace(vbLf, Nothing)
                    End If
                    If cols(cols.Length - 1).ToLower.Contains(vbCrLf) Then
                        cols(cols.Length - 1) = cols(cols.Length - 1).Replace(vbCrLf, Nothing)
                    End If
                    If cols(cols.Length - 1).ToLower.Contains(vbCr) Then
                        cols(cols.Length - 1) = cols(cols.Length - 1).Replace(vbCr, Nothing)
                    End If
                    stemp = stemp.Remove(0, stemp.ToLower.IndexOf("</" & coltype & ">") + 5)
                Else
                    stemp = ""
                End If
            Loop
            Return cols
        End Function
    End Class

    Public Class pList
        Public cntItem As Integer = 0

        Public Function Convert_List_XML(ByVal Markup As String) As Xml.XmlDocument
            If Not Markup.ToLower.Contains("<ul") And Not Markup.ToLower.Contains("<ol") Then
                Throw New ApplicationException("Provided markup does not begin with the <ul/> or <ol/> tag!")
            End If
            If Not Markup.ToLower.Contains("<li") Then
                Throw New ApplicationException("Provided markup does not contain proper <li> tag(s)!")
            End If
            Dim ds As New Xml.XmlDocument
            Dim dc As Xml.XmlElement = ds.CreateElement("List")
            ds.AppendChild(Recursive_ListGatherer(dc, Markup, ds))
            Return ds
        End Function
        Private Function Recursive_ListGatherer(ByVal liNode As Xml.XmlElement, ByVal Markup As String, ByRef xDoc As Xml.XmlDocument) As Xml.XmlElement
            Dim srch As String = "foo"
            Dim newX As Xml.XmlElement
            Dim tmp As String

            If Markup.Contains("&gt;") Then Markup = Markup.Replace("&gt;", ">")
            If Markup.Contains("&lt;") Then Markup = Markup.Replace("&lt;", "<")

            srch = PeakTag(Markup).ToLower
            Do Until Array.IndexOf({"ol", "ul", "li"}, srch) < 0 Or String.IsNullOrEmpty(srch)
                If Array.IndexOf({"ol", "ul", "li"}, srch) > -1 And Not String.IsNullOrEmpty(srch) Then
                    newX = xDoc.CreateElement(srch)

                    If Markup.Contains("&gt;") Then Markup = Markup.Replace("&gt;", ">")
                    If Markup.Contains("&lt;") Then Markup = Markup.Replace("&lt;", "<")

                    tmp = Markup.Remove(0, Markup.IndexOf(">") + 1)
                    If tmp.Contains("</" & srch & ">") Then
                        tmp = tmp.Remove(tmp.IndexOf("</" & srch & ">"))
                    Else
                        tmp = ""
                    End If
                    If HasMarkup(tmp) = 0 Then
                        newX.InnerText = tmp
                    Else
                        If tmp.Contains("<li") Or tmp.Contains("<ol") Or tmp.Contains("<ul") Then
                            newX.AppendChild(Recursive_ListGatherer(newX, tmp, xDoc))
                        Else
                            newX.InnerText = StripHTMLMarkup(tmp)
                        End If
                    End If
                    cntItem += 1
                    If srch = "li" Then
                        If Not IsNothing(liNode.ParentNode) Then
                            liNode.ParentNode.AppendChild(newX)
                        Else
                            liNode.AppendChild(newX)
                        End If
                    Else
                        liNode.AppendChild(newX)
                    End If
                End If

                If Markup.Contains("&gt;") Then Markup = Markup.Replace("&gt;", ">")
                If Markup.Contains("&lt;") Then Markup = Markup.Replace("&lt;", "<")

                Markup = Markup.Remove(Markup.IndexOf("<" & srch), Markup.IndexOf("</" & srch & ">") - Markup.IndexOf("<" & srch) + 1)
                srch = PeakTag(Markup).ToLower
            Loop
            Return liNode
        End Function
    End Class

End Class

Public Module ParsingFuncs

    ''' <summary>
    ''' Removes any HTML tags with Start and End Tags
    ''' </summary>
    ''' <param name="Markup"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StripHTMLMarkup(ByVal Markup As String) As String
        Dim hm As Integer = HasMarkup(Markup)
        Do Until hm = 0
            hm = HasMarkup(Markup)
            If hm > 0 Then
                Markup = Markup.Replace(
                    Markup.Substring(Markup.IndexOf("<"), Markup.IndexOf(">") - Markup.IndexOf("<") + 1), Nothing)
                If Markup.Contains("<") And Markup.Contains(">") Then
                    Markup = Markup.Replace(
                        Markup.Substring(Markup.IndexOf("<"), Markup.IndexOf(">") - Markup.IndexOf("<") + 1), Nothing)
                End If
            ElseIf hm < 0 Then
                Markup = Markup.Replace(
                    Markup.Substring(Markup.IndexOf("<"), Markup.IndexOf(">") - Markup.IndexOf("<") + 1), Nothing)
            End If
        Loop
        Return Markup
    End Function
    ''' <summary>
    ''' Determines whether the provided HTML markup contains an HTML tag with both Start and End tags or it contains only a Start tag.
    ''' </summary>
    ''' <param name="Markup"></param>
    ''' <returns>-1: Only Start tag
    ''' 0: No HTML markup
    ''' 1: Both Start and End tags</returns>
    ''' <remarks></remarks>
    Public Function HasMarkup(ByVal Markup As String) As Integer
        If Markup.Contains("</") Then
            Return 1
        ElseIf Markup.Contains("/>") Then
            Return -1
        Else
            Return 0
        End If
    End Function
    ''' <summary>
    ''' Returns the name of the next potential tag. Returns empty string if improper search.
    ''' </summary>
    ''' <param name="Markup">Raw HTML Markup to search</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PeakTag(ByVal Markup As String) As String
        Dim tmp As String
        'Find next available tag
        If Markup.Contains("<") Then
            'Double check if end tag exists
            If Markup.Contains("</") Then
                If Not Markup.IndexOf("<") > Markup.IndexOf("</") Then
                    'Good to find tag name
                    tmp = Markup.Remove(0, Markup.IndexOf("<") + 1)
                    If tmp.Contains(" ") And tmp.Contains(">") Then
                        If tmp.IndexOf(" ") < tmp.IndexOf(">") Then
                            tmp = tmp.Remove(tmp.IndexOf(" "))
                        Else
                            tmp = tmp.Remove(tmp.IndexOf(">"))
                        End If
                    ElseIf tmp.Contains(">") Then
                        tmp = tmp.Remove(tmp.IndexOf(">"))
                    Else
                        tmp = tmp.Remove(tmp.IndexOf(" "))
                    End If
                    Return tmp
                End If
            ElseIf Markup.Contains("/>") Then
                'Good to find tag name
                tmp = Markup.Remove(0, Markup.IndexOf("<") + 1)
                If tmp.Contains(" ") And tmp.Contains(">") Then
                    If tmp.IndexOf(" ") < tmp.IndexOf(">") Then
                        tmp = tmp.Remove(tmp.IndexOf(" "))
                    Else
                        tmp = tmp.Remove(tmp.IndexOf(">"))
                    End If
                ElseIf tmp.Contains(">") Then
                    tmp = tmp.Remove(tmp.IndexOf(">"))
                Else
                    tmp = tmp.Remove(tmp.IndexOf(" "))
                End If
                Return tmp
            End If
        End If
        Return ""
    End Function

End Module
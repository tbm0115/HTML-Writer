# HTML-Writer
A .NET 2.0 library for generating HTML markup.

The purpose of this library is to provide a clean alternative to "hard-coded" strings of HTML markup in .NET applications. Ideally, 
new classes will be added to the solution to allow the creation of more HTML5 and CSS3 (or whatever comes next).

#Background
This library was created for use within a small machine shop. Custom applications required simple reporting features and writing 
HTML5 markup in string variables "muddy"ed up the code. So, the solution was to hide it and robust the code in a class.

The library started within .NET 3.5 framework, but hardware requirements within the shop forced a change to .NET 2.0.


#Available HTML
<ul>
  <li>"Form" (basically a fieldset with addition of text labels and textboxes)</li>
  <li>Header</li>
  <li>Paragraph</li>
  <li>Table
    <ul>
      <li>Table Header {DELETED}</li>
      <li>Table Row
        <ul>
          <li>Table Cell</li>
        </ul>
      </li>
    </ul>
  </li>
  <li>Image Map
    <ul>
      <li>Map Area</li>
    </ul>
  </li>
  <li>List (with Types)
    <ul>
      <li>List Item</li>
    </ul>
  </li>
  <li>Image</li>
  <li>Canvas</li>
  <li>Anchor</li>
  <li>Input</li>
  <li>Label</li>
  <li>Select</li>
  <li>Progress</li>
  <li>Meter</li>
  <li>Video</li>
  <li>Audio</li>
</ul>

#Usage
Import the HTML library to your project and <pre><code>Imports HTML.HTMLWriter</code></pre> to get started.

Start with an <pre><code>HTMLWriter</code></pre> object and work from there.

Example:
Write a simple table
<pre>
<code>
Imports HTML, HTMLWriter

Public Class Form1
  Public Sub GenerateHTMLReport(ByVal FilePath As String)
    Dim Report As New HTMLWriter

    'Begin writing report data to HTML Table
    Dim Table As New HTMLTable
    'Add Attribute Style to table header with the provided CSS
    Dim TH As New HTMLTable.HTMLTableRow(New AttributeList({"background-color"}, {"lightblue"}, True))
    TH.AddTableCell(New HTMLTableCell("Column 1", HTMLTableCell.CellType.Header))
    TH.AddTableCell(New HTMLTableCell("Column 2", HTMLTableCell.CellType.Header))
    TH.AddTableCell(New HTMLTableCell("Column 3", HTMLTableCell.CellType.Header))
    TH.AddTableCell(New HTMLTableCell("Column 4", HTMLTableCell.CellType.Header))
    TH.AddTableCell(New HTMLTableCell("Column 5", HTMLTableCell.CellType.Header))
    Table.AddTableRow(TH)
    Dim TR As HTMLTable.HTMLTableRow

    For i = 0 To 10 Step 1
      'Offset Color
      If i And 1 Then
        'Add Attribute Style to table row with the provided CSS
        TR = New HTMLTable.HTMLTableRow(New AttributeList({"background-color"}, {"lightgray"}, True))
      Else
        TR = New HTMLTable.HTMLTableRow
      End If
      For j = 0 To 5 Step 1
        TR += New HTMLTableCell(j.ToString, HTMLTableCell.CellType.Row)
      Next
      Debug.WriteLine(vbTab & "Added '" & TR.Count.ToString & "' cells to the row...")
      Table += TR
    Next
    Debug.WriteLine("Added '" & Table.Count.ToString & "' rows to the table...")
    'Add HTML objects to "Report"
    Report += New HTMLHeader("Hello World")
    Report += Table
    'Write all HTML markup to specified file (passed in sub)
    File.WriteAllText(FilePath, Report.HTMLMarkup)
  End Sub
End Class
</code></pre>

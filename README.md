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
  <li>Table
    <ul>
      <li>Table Header</li>
      <li>Table Row</li>
    </ul>
  </li>
  <li>Image Map
    <ul>
      <li>Area</li>
    </ul>
  </li>
  <li>List
    <ul>
      <li>Ordered List</li>
      <li>Unordered List</li>
    </ul>
  </li>
  <li>Image</li>
  <li>Canvas</li>
</ul>

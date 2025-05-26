# Introduction to CSS: Styling Webpages

## What is CSS?
CSS (Cascading Style Sheets) is used to style and format HTML content, controlling aspects like colors, fonts, layouts, and spacing. It enhances the visual appeal and usability of webpages. This guide covers common CSS properties, styling tables, and creating components like dropdown menus and styled lists, with a practical example.

## Common CSS Concepts and Properties
1. **Selectors**:
   - **Element Selector**: Targets HTML tags (e.g., `p { color: blue; }`).
   - **Class Selector**: Targets elements with a specific class (e.g., `.highlight { background: yellow; }`).
   - **ID Selector**: Targets a unique element (e.g., `#header { font-size: 24px; }`).
   - **Pseudo-classes**: Style elements based on state (e.g., `a:hover { color: red; }`).

2. **Text and Font Properties**:
   - `color`: Sets text color (e.g., `color: #333;`).
   - `font-family`: Specifies the font (e.g., `font-family: Arial, sans-serif;`).
   - `font-size`: Sets text size (e.g., `font-size: 16px;`).
   - `font-weight`: Controls text boldness (e.g., `font-weight: bold;`).
   - `text-align`: Aligns text (e.g., `text-align: center;`).

3. **Box Model Properties**:
   - `margin`: Sets space outside an element (e.g., `margin: 10px;`).
   - `padding`: Sets space inside an element (e.g., `padding: 15px;`).
   - `border`: Defines a border (e.g., `border: 1px solid black;`).
   - `width` and `height`: Set element dimensions (e.g., `width: 300px;`).

4. **Background and Colors**:
   - `background-color`: Sets background color (e.g., `background-color: #f0f0f0;`).
   - `background-image`: Adds a background image (e.g., `background-image: url('bg.jpg');`).
   - `opacity`: Controls transparency (e.g., `opacity: 0.8;`).

5. **Positioning and Layout**:
   - `display`: Controls element display (e.g., `display: block;` or `display: flex;`).
   - `position`: Sets positioning method (e.g., `position: relative;` or `position: absolute;`).
   - `float`: Floats elements (e.g., `float: left;`).
   - `margin: auto`: Centers block elements horizontally.

6. **Table Styling**:
   - `border-collapse`: Merges table borders (e.g., `border-collapse: collapse;`).
   - `border-spacing`: Sets space between table cells (e.g., `border-spacing: 5px;`).
   - `text-align` and `padding`: Improve table readability.

7. **Pseudo-elements and Interactivity**:
   - `::before` and `::after`: Add content before/after an element.
   - `:hover`: Styles elements on mouse hover (e.g., `button:hover { background: blue; }`).

## Example: A Styled Webpage with Tables, Dropdown, and Lists
Below is an HTML file with CSS styling, demonstrating the above properties, a styled table, a dropdown menu, and a visually appealing list.

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Styled CSS Webpage</title>
    <style>
        /* General Page Styling */
        body {
            font-family: 'Arial', sans-serif;
            background-color: #e8f4f8;
            margin: 0;
            padding: 20px;
            color: #333;
        }

        /* Header Styling */
        header {
            background-color: #2c3e50;
            color: white;
            text-align: center;
            padding: 20px;
            border-radius: 8px;
        }

        h1 {
            font-size: 32px;
            margin: 0;
        }

        /* Dropdown Menu */
        .dropdown {
            position: relative;
            display: inline-block;
            margin: 15px 0;
        }

        .dropdown-button {
            background-color: #3498db;
            color: white;
            padding: 10px 20px;
            border: none;
            cursor: pointer;
            font-size: 16px;
            border-radius: 5px;
        }

        .dropdown-content {
            display: none;
            position: absolute;
            background-color: #f9f9f9;
            min-width: 160px;
            box-shadow: 0px 8px 16px rgba(0,0,0,0.2);
            z-index: 1;
            border-radius: 5px;
        }

        .dropdown-content a {
            color: #333;
            padding: 12px 16px;
            text-decoration: none;
            display: block;
        }

        .dropdown-content a:hover {
            background-color: #3498db;
            color: white;
        }

        .dropdown:hover .dropdown-content {
            display: block;
        }

        .dropdown-button:hover {
            background-color: #2980b9;
        }

        /* Styled List */
        .styled-list {
            list-style: none;
            padding: 0;
            margin: 20px 0;
        }

        .styled-list li {
            background-color: #fff;
            margin: 5px 0;
            padding: 10px;
            border-left: 5px solid #3498db;
            border-radius: 4px;
            transition: transform 0.2s;
        }

        .styled-list li:hover {
            transform: translateX(10px);
        }

        /* Table Styling */
        table {
            width: 100%;
            max-width: 600px;
            border-collapse: collapse;
            margin: 20px 0;
            background-color: #fff;
            box-shadow: 0 2px 5px rgba(0,0,0,0.1);
        }

        th, td {
            padding: 12px;
            text-align: left;
            border: 1px solid #ddd;
        }

        th {
            background-color: #2c3e50;
            color: white;
            font-weight: bold;
        }

        tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        tr:hover {
            background-color: #e8f4f8;
        }

        /* Footer Styling */
        footer {
            text-align: center;
            margin-top: 20px;
            font-size: 14px;
            color: #777;
        }
    </style>
</head>
<body>
    <header>
        <h1>Learn CSS Styling</h1>
    </header>

    <section>
        <h2>Interactive Components</h2>
        <!-- Dropdown Menu -->
        <div class="dropdown">
            <button class="dropdown-button">Menu</button>
            <div class="dropdown-content">
                <a href="#home">Home</a>
                <a href="#tutorials">Tutorials</a>
                <a href="#resources">Resources</a>
            </div>
        </div>

        <!-- Styled List -->
        <h3>Reasons to Learn CSS</h3>
        <ul class="styled-list">
            <li>Enhances webpage aesthetics</li>
            <li>Improves user experience</li>
            <li>Enables responsive design</li>
        </ul>
    </section>

    <section>
        <h2>Styled Table</h2>
        <table>
            <tr>
                <th>Property</th>
                <th>Description</th>
            </tr>
            <tr>
                <td>color</td>
                <td>Sets the text color</td>
            </tr>
            <tr>
                <td>font-family</td>
                <td>Specifies the font</td>
            </tr>
            <tr>
                <td>border</td>
                <td>Defines element borders</td>
            </tr>
        </table>
    </section>

    <footer>
        <p>© 2025 CSS Learning Hub. All rights reserved.</p>
    </footer>
</body>
</html>
```

### Explanation of the Example
- **General Styling**: The `body` has a light background, consistent font, and padding for a clean layout.
- **Header**: A dark background with rounded corners and centered text for a modern look.
- **Dropdown Menu**:
  - Uses `.dropdown` and `.dropdown-content` with `position: absolute` for positioning.
  - `:hover` pseudo-class shows the menu and changes button color.
  - Links in the dropdown have hover effects for interactivity.
- **Styled List**:
  - Removes default list bullets with `list-style: none`.
  - Adds a colored border and hover animation (`transition: transform`) for visual appeal.
- **Table**:
  - Uses `border-collapse: collapse` for clean borders.
  - Alternating row colors (`tr:nth-child(even)`) and hover effects improve readability.
  - `box-shadow` adds a subtle 3D effect.
- **Footer**: Centered with a muted color for a professional finish.

## Practice Exercises
1. Modify the table’s border color and add a new row with a CSS property and description.
2. Change the dropdown button’s background color and add another menu item.
3. Style the list items with a different `border-left` color and experiment with other hover effects (e.g., change `background-color`).
4. Add a new section with a styled `<div>` using `display: flex` to arrange content side by side.

## Notes for Students
- Save this code in a `.html` file and open it in a browser to see the styled components.
- Experiment with CSS properties like `font-size`, `padding`, or `background-color` to customize the look.
- Try adding new CSS rules to style other HTML elements, such as `<p>` or `<h3>`.
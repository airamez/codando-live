# Introduction to CSS: Styling Webpages

CSS (Cascading Style Sheets) is used to style and format HTML content, controlling aspects like colors, fonts, layouts, and spacing.
It enhances the visual appeal and usability of webpages.

## The HTML Class Attribute

The class attribute in HTML is used to assign one or more identifiers (called classes) to HTML elements, allowing them to be targeted and styled with CSS. Classes are reusable, meaning multiple elements can share the same class, and a single element can have multiple classes. This makes the class attribute a powerful tool for applying consistent styles across different parts of a webpage.

* Example:

  ```html
  <p class="highlight">This paragraph is styled.</p>
  <div class="container main-box">This div has two classes.</div>
  ```

## **Selectors**

* **Element Selector**: Targets HTML tags: `p { color: blue; }`
* **Class Selector**: Targets elements with a specific class: `.highlight { background: yellow; }`
* **ID Selector**: Targets a unique element: `#header { font-size: 24px; }`
* **Pseudo-classes**: Style elements based on state: `a:hover { color: red; }`

## CSS Attributes

* **Text and Font Properties**:
  * **color**: Sets text color: `color: #333;`.
  * **font-family**: Specifies the font: `font-family: Arial, sans-serif;`
  * **font-size**: Sets text size: `font-size: 16px;`
  * **font-size**: Sets text size: `font-size: 16px;`
  * **font-weight**: Controls text boldness: `font-weight: bold;`
  * **text-align**: Aligns text: `text-align: center;`

* **Box Model Properties**:
  * **margin**: Sets space outside an element: `margin: 10px;`
  * **padding**: Sets space inside an element: `padding: 15px;`
  * **border**: Defines a border: `border: 1px solid black;`
  * **width** and **height**: Set element dimensions: `width: 300px;height: 300x`

* **Background and Colors**:
  * **background-color** Sets background color: `background-color: #f0f0f0;`
  * **background-image** Adds a background image: `background-image: url('bg.jpg');`
  * **opacity** Controls transparency: `opacity: 0.8;`

* **Positioning and Layout**:
  * **display** Controls element display: `display: block;` or `display: flex;`
  * **position** Sets positioning method: `position: relative;` or `position: absolute;`
  * **float** Floats elements: `float: left;`
  * **margin: auto** Centers block elements horizontally.

* **Table Styling**:
  * **border-collapse** Merges table borders: `border-collapse: collapse;`
  * **border-spacing** Sets space between table cells: `border-spacing: 5px;`
  * **text-align**  and **padding** Improve table readability.

* **Pseudo-elements and Interactivity**:
  * **::before** and **:after** Add content before/after an element.
  * **:hover** Styles elements on mouse hover: `button:hover { background: blue; }`

## How to add CSS to an HTML page

* Inline
  * CSS is added directly to an HTML element using the style attribute.
  * Use Case: Best for quick, one-off styles or testing. Not recommended for large projects due to maintenance challenges.
  * Advantages:
    * Immediate application
    * No additional files needed.
  * Limitations
    * Hard to maintain
    * Overrides other styles
    * Mixes content with presentation
  * Example
  
    ```html
    <p style="color: blue; font-size: 16px;">This is a styled paragraph.</p>
    ```

* Internal
  * CSS is placed within a `<style>` tag in the `<head>` section of an HTML document.
  * Use Case: Suitable for single-page applications or small projects where styles are specific to one page.
  * Advantages: Keeps styles in one place within the HTML file, easier to manage than inline CSS.
  * Limitations: Not reusable across multiple pages, increases HTML file size.
  * Example

    ```html
    <head>
      <style>
        p { color: green; font-size: 14px; }
      </style>
    </head>
    ```

* External
  * CSS is written in a separate .css file and linked to the HTML using a `<link>` tag
  * Use Case: Ideal for large projects or websites with multiple pages requiring consistent styling.
  * Advantages: Reusable across multiple pages, easier to maintain, separates content from presentation.
  * Limitations: None.
  * Example

    ```html
    <head>
      <link rel="stylesheet" href="styles.css">
    </head>
    ```

* Examples
  * [_05_Demo.html](_05_Demo.html)
    * [_05_Style.css](_05_Style.css)
  * [_06_Form.html](_06_Form.html)
    * [_06_Style.css](_06_Style.css)
  * [_07_Advanced.html](_07_Advanced.html)
    * [_07_Style.css](_07_Style.css)

>Note: Every browser allow CSS exploration using the Dev Tools

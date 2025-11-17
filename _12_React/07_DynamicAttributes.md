# Dynamic attributes

Dynamic attributes allow you to compute `className` and inline `style` values based on props or state, enabling dynamic styling that responds to component data. Instead of hardcoding CSS classes or styles, you can calculate them using JavaScript expressions, making your UI interactive and adaptive.

**Key Techniques:**

* **Dynamic `className`**: Use ternary operators or conditional logic to apply different CSS classes based on component state
  ```jsx
  const className = isActive ? 'button active' : 'button';
  ```

* **Dynamic `style`**: Create style objects with computed values for inline styling
  ```jsx
  const style = { 
    backgroundColor: isError ? 'red' : 'green',
    padding: '10px' 
  };
  ```

* **Combining Both**: Use both dynamic classes (for base styles) and inline styles (for computed values) together
  ```jsx
  <div className={className} style={style}>Content</div>
  ```

**Common Patterns:**

* Conditional styling based on boolean props (active/inactive, read/unread, enabled/disabled)
* Computing colors, sizes, or positions from numeric props
* Showing visual indicators based on data state (success, warning, error)
* Responsive styling that adapts to prop values

**Best Practices:**

* Extract complex logic into variables before the return statement for readability
* Use CSS classes for static styles and inline styles for truly dynamic values
* Combine multiple class names using template literals: `` `base-class ${condition ? 'extra' : ''}` ``
* Keep inline style objects simple; extract complex styles to CSS files

**Related Documentation:**

* [JavaScript in JSX with Curly Braces](https://react.dev/learn/javascript-in-jsx-with-curly-braces) - Using dynamic expressions in JSX
* [Conditional Rendering](https://react.dev/learn/conditional-rendering) - Conditionally applying different values

Example (component: `Notification.jsx`):

```jsx
import React, { useState } from 'react';
import './Notification.css';

// Notification: displays a list of notifications with dynamic styling
// Shows unread notifications with different colors and allows marking them as read
// Props:
//  - inputNotifications: array of notification objects with { id, message, isRead }
//  - onMarkAsRead: callback function to notify parent when a notification is marked as read
// Example:
//  <Notification inputNotifications={notificationList} onMarkAsRead={handleMarkAsRead} />
export default function Notification({ inputNotifications = [], onMarkAsRead }) {
  const unreadCount = inputNotifications.filter(n => !n.isRead).length;

  const unreadStyle = {
    color: unreadCount > 0 ? 'red' : 'inherit'
  };

  return (
    <div className="notification-container">
      <h3>Notifications (<span style={unreadStyle}>{unreadCount} unread</span>)</h3>
      <div className="notification-list">
        {inputNotifications.map(notif => {
          const className = notif.isRead ? 'notif read' : 'notif unread';

          return (
            <div key={notif.id} className={className}>
              <span className="notif-text">{notif.message}</span>
              {!notif.isRead && (
                <button
                  onClick={() => onMarkAsRead(notif.id)}
                  className="mark-read-btn"
                >
                  Mark as Read
                </button>
              )}
            </div>
          );
        })}
      </div>
    </div>
  );
}
```

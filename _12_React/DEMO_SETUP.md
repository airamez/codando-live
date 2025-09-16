# React Examples Demo Setup

This guide shows you how to run and demo the React examples for your students.

## Quick Start

1. **Navigate to the demo directory:**
   ```bash
   cd _12_React/react-demo
   ```

2. **Start the development server:**
   ```bash
   npm run dev
   ```

3. **Open in browser:**
   - Go to http://localhost:5173/
   - You'll see the demo interface with setup instructions

## Demo Environment Features

The demo app includes:
- 📱 **Navigation tabs** to switch between examples
- 📋 **Setup instructions** for each example
- 🎨 **Professional styling** for presentations
- 📱 **Responsive design** for different screen sizes

## How to Add Examples to the Demo

### Method 1: Copy Individual Examples

To demo a specific example (e.g., HelloWorld):

```bash
# From the react-demo directory
cp ../examples/hello-world/HelloWorld.js src/
cp ../examples/hello-world/HelloWorld.css src/
```

Then edit `src/App.jsx`:
1. Uncomment the import: `import HelloWorld from './HelloWorld';`
2. Uncomment the component in the examples array
3. Save the file - the browser will automatically reload

### Method 2: Copy All Examples at Once

```bash
# From the react-demo directory
cp ../examples/hello-world/HelloWorld.js src/
cp ../examples/hello-world/HelloWorld.css src/
cp ../examples/counter-app/Counter.js src/
cp ../examples/counter-app/Counter.css src/
cp ../examples/todo-list/TodoList.js src/
cp ../examples/todo-list/TodoList.css src/
cp ../examples/user-profile/UserProfile.js src/
cp ../examples/user-profile/UserProfile.css src/
cp ../examples/lifecycle-demo/LifecycleDemo.js src/
cp ../examples/lifecycle-demo/LifecycleDemo.css src/
```

Then uncomment all imports and components in `src/App.jsx`.

## Example Demo Flow

### 1. HelloWorld Component
- **Concepts**: Basic components, JSX, props
- **Demo points**: 
  - Show component structure
  - Explain JSX syntax
  - Demonstrate props with different values
  - Point out conditional rendering

### 2. Counter App
- **Concepts**: useState hook, event handling
- **Demo points**:
  - Show state management with useState
  - Demonstrate event handlers
  - Explain state updates and re-rendering
  - Show multiple state variables

### 3. Todo List
- **Concepts**: Complex state, arrays, forms
- **Demo points**:
  - Complex state management
  - Array operations (add, remove, update)
  - Form handling
  - List rendering with keys
  - Filtering and searching

### 4. User Profile
- **Concepts**: Forms, validation, controlled components
- **Demo points**:
  - Form validation patterns
  - Controlled vs uncontrolled components
  - Object state management
  - Different input types

### 5. Lifecycle Demo
- **Concepts**: useEffect hook, side effects
- **Demo points**:
  - Different useEffect patterns
  - Cleanup functions
  - Data fetching
  - Component lifecycle

## Teaching Tips

### Before Each Demo:
1. **Explain the concept** you're about to demonstrate
2. **Show the code** in your IDE first
3. **Run the example** in the browser
4. **Interact with it** to show the behavior
5. **Modify the code** live to show changes

### During the Demo:
- Use the browser's **Developer Tools** to show:
  - React Developer Tools extension
  - Console logs (especially in LifecycleDemo)
  - Network tab for data fetching examples
  - Elements tab to show DOM updates

### After Each Demo:
- **Ask students questions** about what they observed
- **Encourage modifications** - give them small challenges
- **Show common mistakes** and how to fix them

## Browser Setup for Demos

### Install React Developer Tools:
- Chrome: [React Developer Tools](https://chrome.google.com/webstore/detail/react-developer-tools/fmkadmapgofadopljbjfkapdkoienihi)
- Firefox: [React Developer Tools](https://addons.mozilla.org/en-US/firefox/addon/react-devtools/)

### Useful Browser Settings:
- Open Developer Tools (F12)
- Dock to right side for better visibility
- Enable "Preserve log" in Console tab
- Use "Components" and "Profiler" tabs from React DevTools

## Troubleshooting

### Port Already in Use:
```bash
# Kill process using port 5173
sudo lsof -ti:5173 | xargs kill -9
# Or use a different port
npm run dev -- --port 3000
```

### Module Not Found Errors:
- Make sure you copied the component files to `src/`
- Check that imports in `App.jsx` match the file names
- Ensure CSS files are also copied

### Hot Reload Not Working:
- Save the file again
- Refresh the browser manually
- Restart the dev server: `Ctrl+C` then `npm run dev`

## Alternative Demo Methods

### Option 1: Individual Project per Example
Create separate React apps for each example:
```bash
npm create vite@latest hello-world-demo -- --template react
cd hello-world-demo
npm install
# Copy HelloWorld files and modify App.jsx
npm run dev
```

### Option 2: CodeSandbox (Online Demo)
- Go to https://codesandbox.io
- Create new React sandbox
- Copy/paste the component code
- Share the link with students

### Option 3: Existing React Project
If you have an existing React project:
1. Copy the example files to your `src/` directory
2. Import and use the components in your existing app
3. The examples are self-contained and won't conflict

## Student Exercises

After each demo, give students these challenges:

### HelloWorld:
- Change the greeting message
- Add more props (age, location, etc.)
- Add conditional styling

### Counter:
- Add a "double" button that adds 2
- Set min/max limits
- Add a history of changes

### Todo List:
- Add due dates to todos
- Implement categories
- Add drag-and-drop reordering

### User Profile:
- Add more form fields
- Implement real-time validation
- Add a profile picture upload

### Lifecycle Demo:
- Add a new useEffect example
- Create a custom hook
- Add error boundaries

## Next Steps

After students are comfortable with these examples:
1. **Custom Hooks** - Extract reusable logic
2. **Context API** - Global state management  
3. **React Router** - Multi-page applications
4. **API Integration** - Real backend connections
5. **Testing** - Unit and integration tests
6. **Performance** - Optimization techniques

---

**Happy teaching! 🚀**

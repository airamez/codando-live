import { useState } from 'react' // Hook: useState for local component state
import './App.css'

import HelloWorld from './components/HelloWorld'
import MonthsDropdown from './components/MonthsDropdown' // Child component that uses props and hooks
import ExampleComments from './components/ExampleComments'
import SimpleLayout from './components/SimpleLayout'
import DynamicStyles from './components/DynamicStyles'
import Price from './components/Price'
import UserStatus from './components/UserStatus'
import TodoList from './components/TodoList'
import TodoListWithLoop from './components/TodoListWithLoop'
import PRsReview from './components/PRsReview'
import EventHandling from './components/EventHandling'
import Notification from './components/Notification'
import TextInput from './components/TextInput'
import ChoiceContent from './components/ChoiceContent'
import ControlledForm from './components/ControlledForm'
import ProductCard from './components/ProductCard'
import ProductCardImproved from './components/ProductCardImproved'
import Parent from './components/ParentChild/Parent'

function App() {

  // useState: parent keeps the currently selected month
  // - month: current value
  // - setMonth: setter passed down to child so it can notify the parent
  const [month1, setMonth1] = useState('')

  const [month2, setMonth2] = useState('')

  const sampleTodos = [
    { id: '1', title: 'Buy milk' },
    { id: '2', title: 'Fix bug', due: 'tomorrow' },
    { id: '3', title: 'Read docs', hidden: true },
    { id: '4', title: 'Code review' },
    { id: '5', title: 'Deploy to prod' },
    { id: '6', title: '1:1 with manager' },
  ]

  const adminUser = { name: 'Leila', isAdmin: true, notifications: ['Welcome!', 'Update available', 'Gym', 'Meeting at 10AM'] }

  const regularUser = { name: 'Jose', isAdmin: false, notifications: ['Welcome!', 'Update available', 'Prepare classes'] }

  const reviews = [
    { author: 'Artur', date: '2024-10-15', text: 'Looks good! Everything is well implemented.', status: 1 },
    { author: 'Jose', date: '2024-10-16', text: 'Please fix the typo in line 42 and add more comments.', status: 2 },
    { author: 'Leila', date: '2024-10-17', text: 'This breaks the main functionality. Need to refactor.', status: 3 },
    { author: 'Artur', date: '2024-10-17', text: 'Great work! Clean code and good test coverage.', status: 1 },
    { author: 'Jose', date: '2024-10-18', text: 'Minor issues with naming conventions, but overall good.', status: 3 }
  ]

  // useState creates a state variable that React tracks internally
  // - notificationsList: the current state value (React keeps this in memory)
  // - setNotificationsList: function to update the state (tells React to update and re-render)
  // React maintains the connection between these, so when you call setNotificationsList
  // with a function, React knows to pass the latest notificationsList value as the parameter
  const [notificationsList, setNotificationsList] = useState([
    { id: 1, message: 'Welcome to the React world!', isRead: false },
    { id: 2, message: 'You have a new message from Leila', isRead: false },
    { id: 3, message: 'System update available', isRead: true },
    { id: 4, message: 'Meeting scheduled at 3 PM', isRead: false },
    { id: 5, message: 'Your report is ready', isRead: true },
    { id: 6, message: 'BJJ class at 8PM', isRead: false },
    { id: 7, message: 'Review React content', isRead: false },
  ])

  // Callback function passed to child component to handle marking notifications as read
  // Uses the functional update pattern for setState to avoid stale state issues
  const handleMarkAsRead = (id) => {
    // IMPORTANT: Notice we DON'T reference 'notificationsList' directly here!
    // Instead, we pass a function to setNotificationsList that receives the current state
    // The parameter 'prevNotifications' represents the most up-to-date state value
    // It's called 'prev' (previous) because it's the state value BEFORE this update
    // React guarantees 'prevNotifications' is always current, even with rapid clicks
    setNotificationsList(prevNotifications =>
      // .map() creates a new array by transforming each element
      prevNotifications.map(notif =>
        // For the notification with matching id, create a new object with isRead: true
        // The spread operator {...notif} copies all properties, then we override isRead
        // For all other notifications, return them unchanged
        notif.id === id ? { ...notif, isRead: true } : notif
      )
    )
    // Why NOT use: setNotificationsList(notificationsList.map(...)) ?
    // Because 'notificationsList' could be stale (old value from when function was created)
    // The functional pattern ensures we always work with the latest state
  }

  const [selectedExample, setSelectedExample] = useState('')
  const [textControlled, setTextControlled] = useState('Leila')
  const [cart, setCart] = useState([]);

  // Product objects for ProductCardImproved demonstration
  const products = [
    {
      name: "Smart Watch",
      price: 199.99,
      category: "Electronics",
      inStock: true,
      imageUrl: "https://images.unsplash.com/photo-1523275335684-37898b6baf30?w=300&h=300&fit=crop"
    },
    {
      name: "Backpack",
      price: 79.99,
      category: "Accessories",
      inStock: true,
      imageUrl: "https://images.unsplash.com/photo-1553062407-98eeb64c6a62?w=300&h=300&fit=crop"
    },
    {
      name: "Sunglasses",
      price: 149.99,
      category: "Accessories",
      inStock: false,
      imageUrl: "https://images.unsplash.com/photo-1572635196237-14b3f281503f?w=300&h=300&fit=crop"
    },
    {
      name: "Water Bottle",
      price: 24.99,
      category: "Sports",
      inStock: true,
      imageUrl: "https://images.unsplash.com/photo-1602143407151-7111542de6e8?w=300&h=300&fit=crop"
    }
  ];

  const handleAddToCart = (productName) => {
    setCart([...cart, productName])
    alert(`${productName} added to cart! Total items: ${cart.length + 1}`)
  }

  return (
    <>
      <div style={{ marginTop: 12 }}>
        <label htmlFor="exampleSelect">Show example: {selectedExample}</label>
        <select
          id="exampleSelect"
          value={selectedExample}
          onChange={(e) => setSelectedExample(e.target.value)}
          style={{ marginLeft: 8 }}
        >
          <option value="">Select an example</option>
          <option value="hello">Hello World [HelloWorld]</option>
          <option value="months">Select months [MonthsDropdown]</option>
          <option value="comments">1) Comments [ExampleComments]</option>
          <option value="storeJSX">2) Store JSX in variables [SimpleLayout]</option>
          <option value="dynamicStyles">3) Dynamic CSS Styles [DynamicStyles]</option>
          <option value="embed">4) Embed expressions [Price]</option>
          <option value="conditional">5) Conditional rendering [UserStatus]</option>
          <option value="listsMap">6) Render lists (map) [TodoList]</option>
          <option value="listsLoop">6) Render lists (for loop) [TodoListWithLoop]</option>
          <option value="functionsReturn">7) Functions that return JSX [PRsReview]</option>
          <option value="props">8) Props [ProductCard]</option>
          <option value="propsImproved">8) Props with Object [ProductCardImproved]</option>
          <option value="events">9) Event handlers [EventHandling]</option>
          <option value="parentChild">10) Parent/Child Components [Parent, ChildAdd, ChildRemove]</option>
          <option value="controlled">11) Controlled Components [ControlledForm]</option>
          <option value="dynamic">12) Dynamic attributes [Notification]</option>
          <option value="spread">13) Spread props [TextInput]</option>
          <option value="choice">14) Choice example [ChoiceContent]</option>
        </select>
      </div>

      <section style={{ display: selectedExample === 'hello' ? 'block' : 'none' }}>
        <HelloWorld />
      </section>

      <section style={{ display: selectedExample === 'months' ? 'block' : 'none' }}>
        <div>
          <label>
            Choose month 1:{' '}
            {
              /* Props:
                - value: current selected month (from parent state)
                - onChange: callback the child calls with the new month
              */
            }
            <MonthsDropdown value={month1} onChange={setMonth1} />
            <MonthsDropdown value={month2} onChange={setMonth2} />
          </label>
          <p>Selected months: {month1} - {month2}</p>
        </div>
      </section>

      {/* Sections toggle visibility via CSS (display) */}
      <div style={{ marginTop: 16 }}>

        <section
          style={{ display: selectedExample === 'comments' ? 'block' : 'none' }}>
          <h3>1) Comments</h3>
          <ExampleComments />
        </section>

        <section
          style={{ display: selectedExample === 'storeJSX' ? 'block' : 'none' }}>
          <h3>2) JSX as variables</h3>
          <SimpleLayout />
        </section>

        <section
          style={{ display: selectedExample === 'dynamicStyles' ? 'block' : 'none' }}>
          <h3>3) Dynamic CSS Styles</h3>
          <DynamicStyles initialColor="white" initialSize={18} />
        </section>

        <section
          style={{ display: selectedExample === 'embed' ? 'block' : 'none' }}>
          <h3>4) Embed expressions Demo</h3>
          <Price amount={95.10} taxRate={0.35} />
          <Price amount={29.90} taxRate={0.12} />
          <Price amount={150.00} taxRate={0.50} />
        </section>

        <section
          style={{ display: selectedExample === 'conditional' ? 'block' : 'none' }}>
          <h3>5) Conditional rendering</h3>
          <UserStatus user={adminUser} />
          <UserStatus user={regularUser} />
          <UserStatus user={null} />
        </section>

        <section
          style={{ display: selectedExample === 'listsMap' ? 'block' : 'none' }}>
          <h3>6) Render lists (map)</h3>
          <TodoList todos={sampleTodos} />
        </section>

        <section
          style={{ marginTop: 12, display: selectedExample === 'listsLoop' ? 'block' : 'none' }}>
          <h3>6b) Render lists (for loop)</h3>
          <TodoListWithLoop todos={sampleTodos} />
        </section>

        <section
          style={{ display: selectedExample === 'functionsReturn' ? 'block' : 'none' }}>
          <h3>7) Functions that return JSX - PR Reviews</h3>
          <PRsReview reviews={reviews} />
        </section>

        <section
          style={{ display: selectedExample === 'props' ? 'block' : 'none' }}>
          <h3>8) Props (Properties) - Product Cards</h3>
          <p>Cart: {cart.length} items - {cart.join(', ')}</p>
          <div style={{ display: 'flex', flexWrap: 'wrap' }}>
            <ProductCard
              name="Laptop"
              price={999.99}
              category="Electronics"
              inStock={true}
              onAddToCart={handleAddToCart}
              imageUrl="https://images.unsplash.com/photo-1496181133206-80ce9b88a853?w=300&h=300&fit=crop"
            />

            <ProductCard
              name="Coffee Mug"
              price={12.50}
              category="Kitchen"
              inStock={true}
              onAddToCart={handleAddToCart}
              imageUrl="https://images.unsplash.com/photo-1514228742587-6b1558fcca3d?w=300&h=300&fit=crop"
            />

            <ProductCard
              name="Headphones"
              price={199.99}
              category="Electronics"
              inStock={false}
              onAddToCart={handleAddToCart}
              imageUrl="https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=300&h=300&fit=crop"
            />

            <ProductCard
              name="Mystery Box"
              price={49.99}
              onAddToCart={handleAddToCart}
              imageUrl="https://images.unsplash.com/photo-1513542789411-b6a5d4f31634?w=300&h=300&fit=crop"
            />
          </div>
        </section>

        <section
          style={{ display: selectedExample === 'propsImproved' ? 'block' : 'none' }}>
          <h3>8b) Props (Properties) - Product Object Approach</h3>
          <p>Cart: {cart.length} items - {cart.join(', ')}</p>
          <div style={{ display: 'flex', flexWrap: 'wrap' }}>
            {products.map((product, index) => (
              <ProductCardImproved
                key={index}
                product={product}
                onAddToCart={handleAddToCart}
              />
            ))}
          </div>
        </section>

        <section
          style={{ display: selectedExample === 'events' ? 'block' : 'none' }}>
          <h3>9) Event handlers</h3>
          <EventHandling />
        </section>


        <section
          style={{ display: selectedExample === 'parentChild' ? 'block' : 'none' }}>
          <h3>10) Parent/Child</h3>
          <Parent />
        </section>

        <section
          style={{ display: selectedExample === 'controlled' ? 'block' : 'none' }}>
          <h3>11) Controlled Components</h3>
          <ControlledForm />
        </section>

        <section
          style={{ display: selectedExample === 'dynamic' ? 'block' : 'none' }}>
          <h3>12) Dynamic attributes</h3>
          <div style={{ display: 'flex', gap: '20px', alignItems: 'flex-start', justifyContent: 'flex-start' }}>
            <Notification inputNotifications={notificationsList} onMarkAsRead={handleMarkAsRead} />
            <pre style={{ flex: 1, backgroundColor: '#2d2d2d', color: '#f0f0f0', padding: '10px', borderRadius: '4px', fontSize: '12px', overflow: 'auto', margin: 0, textAlign: 'left' }}>
              {JSON.stringify(notificationsList, null, 2)}
            </pre>
          </div>
        </section>

        <section style={{ textAlign: 'left', fontSize: 25, marginTop: 12, display: selectedExample === 'spread' ? 'block' : 'none' }}>
          <h3>13) Spread props</h3>
          <div>
            1. No attribute:
            <TextInput />
          </div>
          <div>
            2. Single attribute:
            <TextInput placeholder="Your name" />
          </div>
          <div>
            3. Read-only / disabled combo:
            <TextInput value="Read only value" readOnly aria-label="readonly" disabled />
          </div>
          <div>
            4. Controlled example:
            <TextInput
              value={textControlled}
              onChange={(e) => setTextControlled(e.target.value)}
              placeholder="Controlled input"
              maxLength={50}
              style={{ width: 320, padding: 6 }}
            />
            Length: {textControlled.length}
          </div>
          <div>
            5.Styled:
            <TextInput
              placeholder="Email or username"
              inputMode="email"
              className="form-input"
              maxLength={100}
              style={{
                width: 250,
                backgroundColor: '#0bea68ff',
                border: '2px solid #4a90e2',
                color: '#000000ff',
                padding: '8px',
                borderRadius: '6px',
                fontFamily: 'monospace'
              }}
            />
          </div>
        </section>

        <section style={{ marginTop: 12, display: selectedExample === 'choice' ? 'block' : 'none' }}>
          <h3>13) Choice example</h3>
          <ChoiceContent choice={1} />
          <ChoiceContent choice={2} />
          <ChoiceContent choice={3} />
          <ChoiceContent choice={5} />
        </section>
      </div>
    </>
  )
}

export default App

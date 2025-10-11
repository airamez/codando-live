import { useState } from 'react' // Hook: useState for local component state
import './App.css'

import HelloWorld from './components/HelloWorld'
import MonthsDropdown from './components/MonthsDropdown' // Child component that uses props and hooks
import ExampleComments from './components/ExampleComments'
import SimpleLayout from './components/SimpleLayout'
import Price from './components/Price'
import UserStatus from './components/UserStatus'
import TodoList from './components/TodoList'
import TodoListWithLoop from './components/TodoListWithLoop'
import ExampleFunctionsReturnJSX from './components/ExampleFunctionsReturnJSX'
import Counter from './components/Counter'
import Notification from './components/Notification'
import TextInput from './components/TextInput'
import ChoiceContent from './components/ChoiceContent'

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
  ]

  const adminUser = { name: 'Leila', isAdmin: true, notifications: ['Welcome!', 'Update available'] }

  const regularUser = { name: 'Jose', isAdmin: false, notifications: ['Welcome!', 'Update available', 'Prepare classes'] }

  const sampleComment = { author: 'Bob', time: '2h', text: 'Looks good!', authorInfo: { avatar: '', name: 'Bob' } }

  const [selectedExample, setSelectedExample] = useState('')
  const [textControlled, setTextControlled] = useState('Alice')

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
          <option value="embed">3) Embed expressions [Price]</option>
          <option value="conditional">4) Conditional rendering [UserStatus]</option>
          <option value="listsMap">5) Render lists (map) [TodoList]</option>
          <option value="listsLoop">5) Render lists (for loop) [TodoListWithLoop]</option>
          <option value="functionsReturn">6) Functions that return JSX [ExampleFunctionsReturnJSX]</option>
          <option value="events">7) Event handlers [Counter]</option>
          <option value="dynamic">8) Dynamic attributes [Notification]</option>
          <option value="spread">9) Spread props [TextInput]</option>
          <option value="choice">10) Choice example [ChoiceContent]</option>
        </select>
      </div>

      <section style={{ marginTop: 12, display: selectedExample === 'hello' ? 'block' : 'none' }}>
        <HelloWorld />
      </section>

      <section style={{ marginTop: 12, display: selectedExample === 'months' ? 'block' : 'none' }}>
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

        <section style={{ marginTop: 12, display: selectedExample === 'comments' ? 'block' : 'none' }}>
          <h3>1) Comments</h3>
          <ExampleComments />
        </section>

        <section style={{ marginTop: 12, display: selectedExample === 'storeJSX' ? 'block' : 'none' }}>
          <h3>2) Store JSX in variables</h3>
          <SimpleLayout />
        </section>

        <section style={{ marginTop: 12, display: selectedExample === 'embed' ? 'block' : 'none' }}>
          <h3>3) Embed expressions</h3>
          <Price amount={42} taxRate={0.07} />
        </section>

        <section style={{ marginTop: 12, display: selectedExample === 'conditional' ? 'block' : 'none' }}>
          <h3>4) Conditional rendering</h3>
          <UserStatus user={adminUser} />
          <UserStatus user={regularUser} />
        </section>

        <section style={{ marginTop: 12, display: selectedExample === 'listsMap' ? 'block' : 'none' }}>
          <h3>5) Render lists (map)</h3>
          <TodoList todos={sampleTodos} />
        </section>

        <section style={{ marginTop: 12, display: selectedExample === 'listsLoop' ? 'block' : 'none' }}>
          <h3>5b) Render lists (for loop)</h3>
          <TodoListWithLoop todos={sampleTodos} />
        </section>

        <section style={{ marginTop: 12, display: selectedExample === 'functionsReturn' ? 'block' : 'none' }}>
          <h3>6) Functions that return JSX</h3>
          <ExampleFunctionsReturnJSX comment={sampleComment} />
        </section>

        <section style={{ marginTop: 12, display: selectedExample === 'events' ? 'block' : 'none' }}>
          <h3>7) Event handlers</h3>
          <Counter />
        </section>

        <section style={{ marginTop: 12, display: selectedExample === 'dynamic' ? 'block' : 'none' }}>
          <h3>8) Dynamic attributes</h3>
          <Notification unread={true} />
          <Notification unread={false} />
        </section>

        <section style={{ marginTop: 12, display: selectedExample === 'spread' ? 'block' : 'none' }}>
          <h3>9) Spread props</h3>
          <p>Single inline usage:</p>
          <TextInput placeholder="Your name" />

          <div style={{ marginTop: 12 }}>
            <div style={{ marginBottom: 8 }}>
              <label style={{ display: 'block', marginBottom: 4 }}>1. Controlled example:</label>
              <TextInput
                value={textControlled}
                onChange={(e) => setTextControlled(e.target.value)}
                placeholder="Controlled input"
                aria-label="controlled-input"
                maxLength={50}
                style={{ width: 320, padding: 6 }}
              />
              {textControlled} : {textControlled.length}
            </div>

            <div style={{ marginBottom: 8 }}>
              <label style={{ display: 'block', marginBottom: 4 }}>2.Styled + ARIA:</label>
              <TextInput
                placeholder="Email or username"
                inputMode="email"
                aria-required={true}
                className="form-input"
                maxLength={100}
                style={{ width: 320 }}
              />
            </div>

            <div style={{ marginBottom: 8 }}>
              <label style={{ display: 'block', marginBottom: 4 }}>3. Read-only / disabled combo:</label>
              <TextInput value="Read only value" readOnly aria-label="readonly" disabled />
            </div>

          </div>
        </section>

        <section style={{ marginTop: 12, display: selectedExample === 'choice' ? 'block' : 'none' }}>
          <h3>Choice example</h3>
          <ChoiceContent choice={3} />
        </section>
      </div>
    </>
  )
}

export default App

import React, { useState } from 'react';

export default function ControlledForm() {
  // Single state object for entire form
  const [formData, setFormData] = useState({
    name: '',
    email: '',
    age: 0,
    country: '',
    subscribe: false,
    gender: '',
    comments: ''
  });

  // Generic change handler for all inputs
  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log('Form submitted:', formData);
    alert(JSON.stringify(formData, null, 2));
  };

  const handleReset = () => {
    setFormData({
      name: '',
      email: '',
      age: 0,
      country: '',
      subscribe: false,
      gender: '',
      comments: ''
    });
  };

  return (
    <form onSubmit={handleSubmit} style={{ display: 'flex', flexDirection: 'column', gap: '10px', maxWidth: '400px' }}>
      <h3>Controlled Form Demo</h3>

      <input
        type="text"
        name="name"
        value={formData.name}
        onChange={handleChange}
        placeholder="Name"
      />

      <input
        type="email"
        name="email"
        value={formData.email}
        onChange={handleChange}
        placeholder="Email"
      />

      <input
        type="number"
        name="age"
        value={formData.age}
        onChange={handleChange}
        placeholder="Age"
      />

      <select name="country" value={formData.country} onChange={handleChange}>
        <option value="">Select Country</option>
        <option value="us">USA</option>
        <option value="ca">Canada</option>
        <option value="uk">UK</option>
        <option value="mx">Mexico</option>
      </select>

      <div>
        <label>Gender:</label>
        <label style={{ marginLeft: '10px' }}>
          <input
            type="radio"
            name="gender"
            value="male"
            checked={formData.gender === 'male'}
            onChange={handleChange}
          />
          Male
        </label>
        <label style={{ marginLeft: '10px' }}>
          <input
            type="radio"
            name="gender"
            value="female"
            checked={formData.gender === 'female'}
            onChange={handleChange}
          />
          Female
        </label>
      </div>

      <label>
        <input
          type="checkbox"
          name="subscribe"
          checked={formData.subscribe}
          onChange={handleChange}
        />
        Subscribe to newsletter
      </label>

      <textarea
        name="comments"
        value={formData.comments}
        onChange={handleChange}
        placeholder="Comments"
        rows="4"
      />

      <div style={{ display: 'flex', gap: '10px' }}>
        <button type="submit">Submit</button>
        <button type="button" onClick={handleReset}>Reset</button>
      </div>

      <div style={{ marginTop: '20px', padding: '10px', backgroundColor: '#f0f0f0', borderRadius: '4px' }}>
        <strong>Current Form State:</strong>
        <pre>{JSON.stringify(formData, null, 2)}</pre>
      </div>
    </form>
  );
}

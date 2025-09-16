// UserProfile.js - Forms and Props Example
import React, { useState } from 'react';
import './UserProfile.css';

/**
 * UserProfile Component
 * 
 * Demonstrates:
 * - Form handling and controlled components
 * - Form validation
 * - Conditional rendering
 * - Props and component composition
 * - Object state management
 * - Event handling patterns
 */
function UserProfile() {
  const [user, setUser] = useState({
    firstName: '',
    lastName: '',
    email: '',
    age: '',
    bio: '',
    country: '',
    interests: [],
    newsletter: false,
    avatar: null
  });

  const [errors, setErrors] = useState({});
  const [isSubmitted, setIsSubmitted] = useState(false);
  const [isEditing, setIsEditing] = useState(true);

  const countries = [
    'United States', 'Canada', 'United Kingdom', 'Germany', 'France',
    'Spain', 'Italy', 'Australia', 'Japan', 'Brazil', 'Other'
  ];

  const availableInterests = [
    'Programming', 'Design', 'Music', 'Sports', 'Reading',
    'Travel', 'Photography', 'Gaming', 'Cooking', 'Art'
  ];

  // Handle input changes
  const handleInputChange = (e) => {
    const { name, value, type, checked } = e.target;
    
    setUser(prevUser => ({
      ...prevUser,
      [name]: type === 'checkbox' ? checked : value
    }));

    // Clear error when user starts typing
    if (errors[name]) {
      setErrors(prevErrors => ({
        ...prevErrors,
        [name]: ''
      }));
    }
  };

  // Handle interest selection
  const handleInterestChange = (interest) => {
    setUser(prevUser => ({
      ...prevUser,
      interests: prevUser.interests.includes(interest)
        ? prevUser.interests.filter(i => i !== interest)
        : [...prevUser.interests, interest]
    }));
  };

  // Validate form
  const validateForm = () => {
    const newErrors = {};

    if (!user.firstName.trim()) {
      newErrors.firstName = 'First name is required';
    }

    if (!user.lastName.trim()) {
      newErrors.lastName = 'Last name is required';
    }

    if (!user.email.trim()) {
      newErrors.email = 'Email is required';
    } else if (!/\S+@\S+\.\S+/.test(user.email)) {
      newErrors.email = 'Email is invalid';
    }

    if (!user.age) {
      newErrors.age = 'Age is required';
    } else if (user.age < 13 || user.age > 120) {
      newErrors.age = 'Age must be between 13 and 120';
    }

    if (!user.country) {
      newErrors.country = 'Please select a country';
    }

    if (user.bio.length > 500) {
      newErrors.bio = 'Bio must be less than 500 characters';
    }

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  // Handle form submission
  const handleSubmit = (e) => {
    e.preventDefault();
    
    if (validateForm()) {
      setIsSubmitted(true);
      setIsEditing(false);
      console.log('User profile submitted:', user);
    }
  };

  // Reset form
  const handleReset = () => {
    setUser({
      firstName: '',
      lastName: '',
      email: '',
      age: '',
      bio: '',
      country: '',
      interests: [],
      newsletter: false,
      avatar: null
    });
    setErrors({});
    setIsSubmitted(false);
    setIsEditing(true);
  };

  // Edit profile
  const handleEdit = () => {
    setIsEditing(true);
    setIsSubmitted(false);
  };

  if (isSubmitted && !isEditing) {
    return <UserProfileDisplay user={user} onEdit={handleEdit} onReset={handleReset} />;
  }

  return (
    <div className="user-profile-container">
      <div className="profile-card">
        <h2>User Profile</h2>
        <p className="subtitle">Please fill out your information</p>

        <form onSubmit={handleSubmit} className="profile-form">
          <div className="form-row">
            <div className="form-group">
              <label htmlFor="firstName">First Name *</label>
              <input
                type="text"
                id="firstName"
                name="firstName"
                value={user.firstName}
                onChange={handleInputChange}
                className={errors.firstName ? 'error' : ''}
                placeholder="Enter your first name"
              />
              {errors.firstName && <span className="error-message">{errors.firstName}</span>}
            </div>

            <div className="form-group">
              <label htmlFor="lastName">Last Name *</label>
              <input
                type="text"
                id="lastName"
                name="lastName"
                value={user.lastName}
                onChange={handleInputChange}
                className={errors.lastName ? 'error' : ''}
                placeholder="Enter your last name"
              />
              {errors.lastName && <span className="error-message">{errors.lastName}</span>}
            </div>
          </div>

          <div className="form-group">
            <label htmlFor="email">Email Address *</label>
            <input
              type="email"
              id="email"
              name="email"
              value={user.email}
              onChange={handleInputChange}
              className={errors.email ? 'error' : ''}
              placeholder="Enter your email address"
            />
            {errors.email && <span className="error-message">{errors.email}</span>}
          </div>

          <div className="form-row">
            <div className="form-group">
              <label htmlFor="age">Age *</label>
              <input
                type="number"
                id="age"
                name="age"
                value={user.age}
                onChange={handleInputChange}
                className={errors.age ? 'error' : ''}
                placeholder="Enter your age"
                min="13"
                max="120"
              />
              {errors.age && <span className="error-message">{errors.age}</span>}
            </div>

            <div className="form-group">
              <label htmlFor="country">Country *</label>
              <select
                id="country"
                name="country"
                value={user.country}
                onChange={handleInputChange}
                className={errors.country ? 'error' : ''}
              >
                <option value="">Select a country</option>
                {countries.map(country => (
                  <option key={country} value={country}>{country}</option>
                ))}
              </select>
              {errors.country && <span className="error-message">{errors.country}</span>}
            </div>
          </div>

          <div className="form-group">
            <label htmlFor="bio">Bio</label>
            <textarea
              id="bio"
              name="bio"
              value={user.bio}
              onChange={handleInputChange}
              className={errors.bio ? 'error' : ''}
              placeholder="Tell us about yourself... (optional)"
              rows="4"
            />
            <div className="char-count">
              {user.bio.length}/500 characters
            </div>
            {errors.bio && <span className="error-message">{errors.bio}</span>}
          </div>

          <div className="form-group">
            <label>Interests</label>
            <div className="interests-grid">
              {availableInterests.map(interest => (
                <label key={interest} className="interest-item">
                  <input
                    type="checkbox"
                    checked={user.interests.includes(interest)}
                    onChange={() => handleInterestChange(interest)}
                  />
                  <span className="checkmark"></span>
                  {interest}
                </label>
              ))}
            </div>
          </div>

          <div className="form-group">
            <label className="checkbox-label">
              <input
                type="checkbox"
                name="newsletter"
                checked={user.newsletter}
                onChange={handleInputChange}
              />
              <span className="checkmark"></span>
              Subscribe to our newsletter
            </label>
          </div>

          <div className="form-actions">
            <button type="button" onClick={handleReset} className="btn btn-secondary">
              Reset
            </button>
            <button type="submit" className="btn btn-primary">
              Save Profile
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}

// Separate component to display the submitted profile
function UserProfileDisplay({ user, onEdit, onReset }) {
  return (
    <div className="user-profile-container">
      <div className="profile-card profile-display">
        <h2>Profile Saved Successfully! ✅</h2>
        
        <div className="profile-info">
          <div className="info-section">
            <h3>Personal Information</h3>
            <div className="info-grid">
              <div className="info-item">
                <label>Name:</label>
                <span>{user.firstName} {user.lastName}</span>
              </div>
              <div className="info-item">
                <label>Email:</label>
                <span>{user.email}</span>
              </div>
              <div className="info-item">
                <label>Age:</label>
                <span>{user.age} years old</span>
              </div>
              <div className="info-item">
                <label>Country:</label>
                <span>{user.country}</span>
              </div>
            </div>
          </div>

          {user.bio && (
            <div className="info-section">
              <h3>Bio</h3>
              <p className="bio-text">{user.bio}</p>
            </div>
          )}

          {user.interests.length > 0 && (
            <div className="info-section">
              <h3>Interests</h3>
              <div className="interests-display">
                {user.interests.map(interest => (
                  <span key={interest} className="interest-tag">
                    {interest}
                  </span>
                ))}
              </div>
            </div>
          )}

          <div className="info-section">
            <div className="info-item">
              <label>Newsletter:</label>
              <span className={user.newsletter ? 'subscribed' : 'not-subscribed'}>
                {user.newsletter ? '✅ Subscribed' : '❌ Not subscribed'}
              </span>
            </div>
          </div>
        </div>

        <div className="form-actions">
          <button onClick={onReset} className="btn btn-secondary">
            Create New Profile
          </button>
          <button onClick={onEdit} className="btn btn-primary">
            Edit Profile
          </button>
        </div>
      </div>
    </div>
  );
}

export default UserProfile;

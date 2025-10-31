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

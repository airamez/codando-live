import React from 'react';

// Notification: shows a different message when there are unread messages.
// Accepts `unread` as either a boolean or a number. Examples:
//  <Notification unread />
//  <Notification unread={3} />
//  <Notification /> // no unread messages
export default function Notification({ unread = 0 }) {
  // Normalize to a count (number)
  const unreadCount = typeof unread === 'number' ? unread : unread ? 1 : 0;

  const hasUnread = unreadCount > 0;
  const className = hasUnread ? 'notif unread' : 'notif';
  const style = { borderLeft: hasUnread ? '4px solid #007bff' : '4px solid transparent', padding: 8 };

  const message = hasUnread
    ? unreadCount === 1
      ? 'You have 1 unread message'
      : `You have ${unreadCount} unread messages`
    : "You're all caught up — no new messages";

  return (
    <div className={className} style={style} aria-live={hasUnread ? 'polite' : 'off'}>
      {message}
    </div>
  );
}

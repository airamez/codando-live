import { useState, useEffect } from 'react';
import './hooks.css';

function UseEffect() {
  const [posts, setPosts] = useState([]);
  const [selectedPostId, setSelectedPostId] = useState('');
  const [postDetails, setPostDetails] = useState(null);
  const [loading, setLoading] = useState(true);
  const [detailsLoading, setDetailsLoading] = useState(false);

  // Effect 1: Fetch list of posts when component mounts
  useEffect(() => {
    fetch('https://jsonplaceholder.typicode.com/posts?_limit=10')
      .then(response => response.json())
      .then(data => {
        setPosts(data);
        setLoading(false);
      })
      .catch(err => {
        console.error('Error fetching posts:', err);
        setLoading(false);
      });
  }, []); // (ATTENTION) Empty array = runs once when component mounts

  // Effect 2: Fetch post details when selectedPostId changes
  useEffect(() => {
    if (!selectedPostId) {
      setPostDetails(null);
      return;
    }

    setDetailsLoading(true);

    // Fetch post details and comments
    Promise.all([
      fetch(`https://jsonplaceholder.typicode.com/posts/${selectedPostId}`).then(r => r.json()),
      fetch(`https://jsonplaceholder.typicode.com/posts/${selectedPostId}/comments`).then(r => r.json())
    ])
      .then(([post, comments]) => {
        setPostDetails({ ...post, comments });
        setDetailsLoading(false);
      })
      .catch(err => {
        console.error('Error fetching details:', err);
        setDetailsLoading(false);
      });
  }, [selectedPostId]); // (ATTENTION) Runs whenever selectedPostId changes

  if (loading) return <p>Loading posts...</p>;

  return (
    <div className="hook-example-section">
      <h3>useEffect Example - Fetching Data with Dependencies</h3>

      <div className="use-effect-container">
        <label htmlFor="post-select" className="use-effect-label">
          Select a post:
        </label>
        <select
          id="post-select"
          value={selectedPostId}
          onChange={(e) => setSelectedPostId(e.target.value)}
          className="use-effect-select"
        >
          <option value="">-- Choose a post --</option>
          {posts.map(post => (
            <option key={post.id} value={post.id}>
              {post.title}
            </option>
          ))}
        </select>
      </div>

      {detailsLoading && <p>Loading details...</p>}

      {postDetails && !detailsLoading && (
        <div className="use-effect-details">
          <h4>{postDetails.title}</h4>
          <p><strong>Post ID:</strong> {postDetails.id}</p>
          <p><strong>Description:</strong> {postDetails.body}</p>

          <h5>Comments ({postDetails.comments.length}):</h5>
          <ul className="use-effect-comments">
            {postDetails.comments.map(comment => (
              <li key={comment.id} className="use-effect-comment-item">
                <strong>{comment.name}</strong> <span className="use-effect-comment-email">({comment.email})</span>
                <p className="use-effect-comment-body">{comment.body}</p>
              </li>
            ))}
          </ul>
        </div>
      )}
    </div>
  );
}

export default UseEffect;


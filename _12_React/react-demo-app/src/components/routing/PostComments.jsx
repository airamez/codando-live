import { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';

function PostComments({ users }) {
  const { postId } = useParams();
  const [loadingComments, setLoadingComments] = useState(true);
  const [post, setPost] = useState(null);
  const [comments, setComments] = useState([]);
  const [user, setUser] = useState(null);

  useEffect(() => {
    if (postId) {
      setLoadingComments(true);
      Promise.all([
        fetch(`https://jsonplaceholder.typicode.com/posts/${postId}`).then(r => r.json()),
        fetch(`https://jsonplaceholder.typicode.com/posts/${postId}/comments`).then(r => r.json())
      ])
        .then(([postData, commentsData]) => {
          setPost(postData);
          setComments(commentsData);
          // Find user from users array
          const foundUser = users.find(u => u.id === postData.userId);
          setUser(foundUser);
          setLoadingComments(false);
        })
        .catch(error => {
          console.error('Error fetching post/comments:', error);
          setLoadingComments(false);
        });
    }
  }, [postId, users]);

  if (loadingComments) {
    return <div>Loading...</div>;
  }

  if (!post) {
    return (
      <div>
        <h2>Post Not Found</h2>
      </div>
    );
  }

  return (
    <div>
      <div className="post-info-box">
        <h2>{post.title}</h2>
        <p>
          <strong>Author:</strong> {user?.name || `User ${post.userId}`} | <strong>Post ID:</strong> {post.id}
        </p>
        <p className="post-body">{post.body}</p>
      </div>

      <h3 className="comments-heading">Comments ({comments.length})</h3>
      {comments.length === 0 ? (
        <p>No comments yet.</p>
      ) : (
        <table className="data-table">
          <thead>
            <tr>
              <th style={{ width: '30%' }}>Name</th>
              <th style={{ width: '20%' }}>Email</th>
              <th style={{ width: '50%' }}>Comment</th>
            </tr>
          </thead>
          <tbody>
            {comments.map(comment => (
              <tr key={comment.id}>
                <td className="bold">{comment.name}</td>
                <td className="gray small">{comment.email}</td>
                <td style={{ lineHeight: '1.5' }}>{comment.body}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}

export default PostComments;

import { useState, useEffect } from 'react';
import { useParams, Link } from 'react-router-dom';

function UserPosts({ users }) {
  const { userId } = useParams();
  const [loadingPosts, setLoadingPosts] = useState(true);
  const [posts, setPosts] = useState([]);
  const user = users.find(u => u.id === parseInt(userId));

  useEffect(() => {
    if (userId) {
      setLoadingPosts(true);
      fetch(`https://jsonplaceholder.typicode.com/users/${userId}/posts`)
        .then(response => response.json())
        .then(data => {
          setPosts(data);
          setLoadingPosts(false);
        })
        .catch(error => {
          console.error('Error fetching posts:', error);
          setLoadingPosts(false);
        });
    }
  }, [userId]);

  if (!user) {
    return (
      <div>
        <h2>User Not Found</h2>
      </div>
    );
  }

  return (
    <div>
      <h2>{user.name}'s Posts ({posts.length})</h2>
      <div className="user-info-box">
        <p>
          <strong>Email:</strong> {user.email} | <strong>Company:</strong> {user.company.name} | <strong>Website:</strong> {user.website}
        </p>
      </div>

      {loadingPosts ? (
        <p>Loading posts...</p>
      ) : (
        <div>
          {posts.length === 0 ? (
            <p>No posts found for this user.</p>
          ) : (
            <table className="data-table">
              <thead>
                <tr>
                  <th style={{ width: '5%' }}>ID</th>
                  <th style={{ width: '25%' }}>Title</th>
                  <th style={{ width: '55%' }}>Body</th>
                  <th className="center" style={{ width: '15%' }}>Actions</th>
                </tr>
              </thead>
              <tbody>
                {posts.map(post => (
                  <tr key={post.id}>
                    <td>{post.id}</td>
                    <td className="bold">{post.title}</td>
                    <td className="gray">{post.body}</td>
                    <td className="center">
                      <Link to={`/routing/user-posts/${post.id}`}>
                        <button className="btn btn-success">
                          View Comments
                        </button>
                      </Link>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          )}
        </div>
      )}
    </div>
  );
}

export default UserPosts;

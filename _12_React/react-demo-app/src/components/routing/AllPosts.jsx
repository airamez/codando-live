import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

function AllPosts({ users }) {
  const [loadingPosts, setLoadingPosts] = useState(true);
  const [allPosts, setAllPosts] = useState([]);

  useEffect(() => {
    setLoadingPosts(true);
    fetch('https://jsonplaceholder.typicode.com/posts')
      .then(response => response.json())
      .then(data => {
        setAllPosts(data.slice(0, 20)); // Limit to 20 posts
        setLoadingPosts(false);
      })
      .catch(error => {
        console.error('Error fetching posts:', error);
        setLoadingPosts(false);
      });
  }, []);

  const getUserName = (userId) => {
    const user = users.find(u => u.id === userId);
    return user ? user.name : `User ${userId}`;
  };

  return (
    <div>
      <h2>All Posts ({allPosts.length})</h2>

      {loadingPosts ? (
        <p>Loading posts...</p>
      ) : (
        <table className="data-table">
          <thead>
            <tr>
              <th style={{ width: '5%' }}>ID</th>
              <th style={{ width: '20%' }}>Author</th>
              <th style={{ width: '25%' }}>Title</th>
              <th style={{ width: '40%' }}>Body</th>
              <th className="center" style={{ width: '10%' }}>Actions</th>
            </tr>
          </thead>
          <tbody>
            {allPosts.map(post => (
              <tr key={post.id}>
                <td>{post.id}</td>
                <td className="small gray">{getUserName(post.userId)}</td>
                <td className="bold">{post.title}</td>
                <td className="gray">{post.body}</td>
                <td className="center">
                  <Link to={`/routing/posts/${post.id}`}>
                    <button className="btn btn-success">View Comments</button>
                  </Link>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}

export default AllPosts;

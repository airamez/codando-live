function displayResult(data) {
  const output = document.getElementById('resultOutput');
  output.value = JSON.stringify(data, null, 2);
  console.log(data);
}

function xhrRequest() {
  const xhr = new XMLHttpRequest();
  xhr.open('GET', 'https://jsonplaceholder.typicode.com/users', true);
  xhr.onreadystatechange = function () {
    if (xhr.readyState === 4 && xhr.status === 200) {
      const data = JSON.parse(xhr.responseText);
      displayResult(data);
    }
  };
  xhr.onerror = () => displayResult({ error: 'XHR request failed' });
  xhr.send();
}

function fetchGetRequest() {
  fetch('https://jsonplaceholder.typicode.com/users')
    .then(response => {
      if (!response.ok) throw new Error('Network response was not ok');
      return response.json();
    })
    .then(data => displayResult(data))
    .catch(error => displayResult({ error: error.message }));
}

function fetchPostRequest() {
  const postInput = document.getElementById('postInput').value;
  try {
    const jsonData = JSON.parse(postInput);
    fetch('https://jsonplaceholder.typicode.com/posts', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(jsonData),
    })
      .then(response => {
        if (!response.ok) throw new Error('Network response was not ok');
        return response.json();
      })
      .then(data => displayResult(data))
      .catch(error => displayResult({ error: error.message }));
  } catch (error) {
    displayResult({ error: 'Invalid JSON input' });
  }
}

async function asyncAwaitRequest() {
  try {
    const userResponse = await fetch('https://jsonplaceholder.typicode.com/users/1');
    if (!userResponse.ok) throw new Error('Failed to fetch user');
    const user = await userResponse.json();

    const postsResponse = await fetch(`https://jsonplaceholder.typicode.com/posts?userId=${user.id}`);
    if (!postsResponse.ok) throw new Error('Failed to fetch posts');
    const posts = await postsResponse.json();

    displayResult({ user, posts });
  } catch (error) {
    displayResult({ error: error.message });
  }
}

function multiUserPostsRequest() {
  // Create an array of Promises for fetching posts
  const promises = [
    fetch('https://jsonplaceholder.typicode.com/posts?userId=1'),
    fetch('https://jsonplaceholder.typicode.com/posts?userId=2'),
    fetch('https://jsonplaceholder.typicode.com/posts?userId=3')
  ];
  // Wait for all Promises to resolve and handle results
  Promise.all(promises.map(promise =>
    promise.then(response => response.json())
  ))
    .then(results => displayResult(results.flat()))
    .catch(error => displayResult({ error: `Failed to fetch posts:${error}` }));
}

function clearResults() {
  document.getElementById("resultOutput").value = "";
}

// Add event listeners when the DOM is fully loaded
document.addEventListener('DOMContentLoaded', () => {
  document.getElementById('xhrButton').addEventListener('click', xhrRequest);
  document.getElementById('fetchGetButton').addEventListener('click', fetchGetRequest);
  document.getElementById('fetchPostButton').addEventListener('click', fetchPostRequest);
  document.getElementById('asyncAwaitButton').addEventListener('click', asyncAwaitRequest);
  document.getElementById('multiUserPostsButton').addEventListener('click', multiUserPostsRequest);
  document.getElementById('clearResultsButton').addEventListener('click', clearResults);
});
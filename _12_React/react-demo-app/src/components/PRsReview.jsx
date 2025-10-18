export default function PRsReview({ reviews }) {

  // helper function that calculates word count
  function getWordCount(text) {
    return text.trim().split(/\s+/).length;
  }

  // helper function to translate status number to text
  function getStatusText(statusNumber) {
    switch (statusNumber) {
      case 1:
        return 'Approved';
      case 2:
        return 'Approved with comments';
      case 3:
        return 'Rejected';
      default:
        return 'Unknown';
    }
  }

  function GetReviewCountByStatus(label, reviews, status) {
    return <p>{label}:{reviews.filter(review => review.status === status).length}</p>
  }

  return (
    <div>
      <h4>Pull Request Reviews</h4>
      <table border="1">
        <thead>
          <tr>
            <th>Date</th>
            <th>Author</th>
            <th>Review Text</th>
            <th>Word Count</th>
            <th>Status</th>
          </tr>
        </thead>
        <tbody>
          {reviews.map((review, index) => (
            <tr key={index}>
              <td>{review.date}</td>
              <td>{review.author}</td>
              <td>{review.text}</td>
              <td>{getWordCount(review.text)}</td>
              <td>{getStatusText(review.status)}</td>
            </tr>
          ))}
        </tbody>
      </table>
      <p>Total reviews: {reviews.length}</p>
      {GetReviewCountByStatus("Approved", reviews, 1)}
      {GetReviewCountByStatus("Approved with comments", reviews, 2)}
      {GetReviewCountByStatus("Rejected", reviews, 3)}
    </div >
  );
}

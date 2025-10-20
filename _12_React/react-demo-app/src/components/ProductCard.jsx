import './ProductCard.css';

export default function ProductCard({
  name,
  price,
  inStock = true,
  category = "General",
  onAddToCart,
  imageUrl
}) {
  return (
    <div className={`product-card ${inStock ? 'in-stock' : 'out-of-stock'}`}>
      <img
        src={imageUrl}
        alt={name}
        className="product-card-image"
      />

      <h3 className="product-card-title">{name}</h3>

      <p className="product-card-category">
        Category: {category}
      </p>

      <p className="product-card-price">
        ${price.toFixed(2)}
      </p>

      <p className={`product-card-stock ${inStock ? 'in-stock' : 'out-of-stock'}`}>
        {inStock ? '✓ In Stock' : '✗ Out of Stock'}
      </p>

      <button
        onClick={() => onAddToCart(name)}
        disabled={!inStock}
        className={`product-card-button ${inStock ? 'available' : 'unavailable'}`}
      >
        {inStock ? 'Add to Cart' : 'Unavailable'}
      </button>
    </div>
  );
}
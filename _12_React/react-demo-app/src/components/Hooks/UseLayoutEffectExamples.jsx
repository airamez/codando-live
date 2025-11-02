import { useState, useEffect, useLayoutEffect, useRef } from 'react';

function UseLayoutEffectExamples() {
  const [show, setShow] = useState(false);
  const [dimensions, setDimensions] = useState({ width: 0, height: 0 });
  const [position, setPosition] = useState({ top: 0, left: 0 });

  const boxRef = useRef(null);
  const tooltipRef = useRef(null);

  // Example 1: useLayoutEffect prevents visual flicker
  useLayoutEffect(() => {
    if (show && boxRef.current) {
      // This happens before paint, no flicker
      boxRef.current.style.transform = 'scale(1)';
      boxRef.current.style.opacity = '1';
    } else if (boxRef.current) {
      boxRef.current.style.transform = 'scale(0.8)';
      boxRef.current.style.opacity = '0';
    }
  }, [show]);

  // Example 2: Measuring DOM elements
  useLayoutEffect(() => {
    if (show && boxRef.current) {
      const { width, height } = boxRef.current.getBoundingClientRect();
      setDimensions({ width, height });
    }
  }, [show]);

  // Example 3: Positioning tooltip based on element
  useLayoutEffect(() => {
    if (show && boxRef.current && tooltipRef.current) {
      const boxRect = boxRef.current.getBoundingClientRect();
      const tooltipRect = tooltipRef.current.getBoundingClientRect();

      // Position tooltip above the box
      setPosition({
        top: boxRect.top - tooltipRect.height - 10,
        left: boxRect.left + (boxRect.width - tooltipRect.width) / 2
      });
    }
  }, [show, dimensions]);

  // Example 4: Scroll position restoration
  const [items] = useState(Array.from({ length: 100 }, (_, i) => `Item ${i + 1}`));
  const listRef = useRef(null);
  const scrollPositionRef = useRef(0);

  useLayoutEffect(() => {
    if (listRef.current) {
      // Restore scroll position before paint
      listRef.current.scrollTop = scrollPositionRef.current;
    }
  });

  const handleScroll = () => {
    if (listRef.current) {
      scrollPositionRef.current = listRef.current.scrollTop;
    }
  };

  // Comparison with useEffect
  const [flickerDemo, setFlickerDemo] = useState(false);
  const flickerRef = useRef(null);

  // useEffect - might cause visible flicker
  useEffect(() => {
    if (flickerDemo && flickerRef.current) {
      flickerRef.current.style.backgroundColor = 'lightblue';
      flickerRef.current.style.transform = 'translateX(100px)';
    } else if (flickerRef.current) {
      flickerRef.current.style.backgroundColor = 'lightcoral';
      flickerRef.current.style.transform = 'translateX(0)';
    }
  }, [flickerDemo]);

  return (
    <div>
      <h3>useLayoutEffect Examples</h3>

      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>Toggle Visibility</h4>
        <button onClick={() => setShow(!show)}>
          {show ? 'Hide' : 'Show'} Elements
        </button>
      </div>

      {/* Example 1 & 2: Animated box with measurements */}
      {show && (
        <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
          <h4>Animated Box (useLayoutEffect)</h4>
          <div
            ref={boxRef}
            style={{
              width: '200px',
              height: '100px',
              backgroundColor: 'lightgreen',
              margin: '20px',
              transform: 'scale(0.8)',
              opacity: '0',
              transition: 'all 0.3s ease',
              display: 'flex',
              alignItems: 'center',
              justifyContent: 'center',
            }}
          >
            Box Element
          </div>

          {/* Example 2: Display dimensions */}
          <p>
            Dimensions: {dimensions.width.toFixed(0)}px × {dimensions.height.toFixed(0)}px
          </p>

          {/* Example 3: Positioned tooltip */}
          {dimensions.width > 0 && (
            <div
              ref={tooltipRef}
              style={{
                position: 'fixed',
                top: `${position.top}px`,
                left: `${position.left}px`,
                backgroundColor: 'black',
                color: 'white',
                padding: '5px 10px',
                borderRadius: '4px',
                fontSize: '14px',
                pointerEvents: 'none',
              }}
            >
              Tooltip (positioned with useLayoutEffect)
            </div>
          )}
        </div>
      )}

      {/* Example 4: Scroll position restoration */}
      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>Scroll Position Restoration</h4>
        <div
          ref={listRef}
          onScroll={handleScroll}
          style={{
            height: '150px',
            overflow: 'auto',
            border: '1px solid #ccc',
            padding: '10px',
          }}
        >
          {items.map(item => (
            <div key={item} style={{ padding: '5px' }}>
              {item}
            </div>
          ))}
        </div>
        <p><small>Scroll position is preserved on re-renders</small></p>
        <button onClick={() => setShow(!show)}>Toggle to test scroll preservation</button>
      </div>

      {/* Comparison: useEffect vs useLayoutEffect */}
      <div style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ddd' }}>
        <h4>Comparison: useEffect (might flicker)</h4>
        <button onClick={() => setFlickerDemo(!flickerDemo)}>
          Toggle (uses useEffect)
        </button>
        <div
          ref={flickerRef}
          style={{
            width: '150px',
            height: '50px',
            backgroundColor: 'lightcoral',
            margin: '20px 0',
            transition: 'all 0.3s ease',
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center',
          }}
        >
          useEffect Demo
        </div>
        <p><small>This uses useEffect - you might see a brief flicker</small></p>
      </div>

      {/* Explanation */}
      <div style={{ marginBottom: '20px', padding: '10px', backgroundColor: '#f0f0f0' }}>
        <h4>useEffect vs useLayoutEffect</h4>
        <table style={{ width: '100%', textAlign: 'left', borderCollapse: 'collapse' }}>
          <thead>
            <tr>
              <th style={{ borderBottom: '1px solid #ccc', padding: '8px' }}>Aspect</th>
              <th style={{ borderBottom: '1px solid #ccc', padding: '8px' }}>useEffect</th>
              <th style={{ borderBottom: '1px solid #ccc', padding: '8px' }}>useLayoutEffect</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td style={{ padding: '8px' }}>Timing</td>
              <td style={{ padding: '8px' }}>After paint</td>
              <td style={{ padding: '8px' }}>Before paint</td>
            </tr>
            <tr>
              <td style={{ padding: '8px' }}>Blocking</td>
              <td style={{ padding: '8px' }}>Non-blocking</td>
              <td style={{ padding: '8px' }}>Blocks visual updates</td>
            </tr>
            <tr>
              <td style={{ padding: '8px' }}>Use for</td>
              <td style={{ padding: '8px' }}>Most side effects</td>
              <td style={{ padding: '8px' }}>DOM measurements, visual changes</td>
            </tr>
            <tr>
              <td style={{ padding: '8px' }}>Flicker</td>
              <td style={{ padding: '8px' }}>Possible</td>
              <td style={{ padding: '8px' }}>Prevented</td>
            </tr>
          </tbody>
        </table>
        <p style={{ marginTop: '10px' }}><strong>Rule:</strong> Use useEffect by default, only use useLayoutEffect when you need synchronous DOM updates.</p>
      </div>
    </div>
  );
}

export default UseLayoutEffectExamples;

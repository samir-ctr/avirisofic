
(function(){
  // If Leaflet is available (local vendor), use it with a blank grid; else fallback to SVG used before.
  if (window.L && typeof L.map === 'function') {
    const mapEl = document.getElementById('map');
    if (!mapEl) return;
    const map = L.map(mapEl, { zoomControl: true }).setView([12.8654, -85.2072], 6);
    // Blank grid layer (no tiles, offline)
    const Blank = L.GridLayer.extend({ createTile: function(coords){ var tile=document.createElement('div'); tile.style.background='#e6f7ee'; return tile; } });
    (new Blank()).addTo(map);

    function addCircle(r){
      const m = L.circleMarker([r.lat, r.lng], { radius: 8, color: '#0a7aa5', weight: 2, fillColor: '#1db4ff', fillOpacity: 0.9 })
        .addTo(map).bindPopup(`<strong>${r.nombre}</strong><br>${r.ciudad} — ${formatUSD(r.precio)}`);
    }
    DATA.reservas.forEach(addCircle);
    return;
  }

  // Fallback SVG map
  const box = document.getElementById('map');
  if (!box) return;
  const B = {latMin:10.8, latMax:15.1, lngMin:-87.8, lngMax:-83.0};
  const w = box.clientWidth, h = box.clientHeight;
  const svgNS = 'http://www.w3.org/2000/svg';
  const svg = document.createElementNS(svgNS, 'svg'); svg.setAttribute('viewBox', `0 0 ${w} ${h}`); svg.style.width='100%'; svg.style.height='100%'; box.appendChild(svg);
  const bg = document.createElementNS(svgNS, 'rect'); bg.setAttribute('x',0); bg.setAttribute('y',0); bg.setAttribute('width',w); bg.setAttribute('height',h); bg.setAttribute('fill','#e6f7ee'); svg.appendChild(bg);
  const coast = document.createElementNS(svgNS,'path'); coast.setAttribute('d',`M 0 ${h*0.2} C ${w*0.2} ${h*0.05}, ${w*0.4} ${h*0.35}, ${w*0.6} ${h*0.25} S ${w*0.9} ${h*0.4}, ${w} ${h*0.3}`); coast.setAttribute('stroke','#cfe8dd'); coast.setAttribute('fill','none'); coast.setAttribute('stroke-width','8'); svg.appendChild(coast);
  function project(lat,lng){ const x = (lng - B.lngMin) / (B.lngMax - B.lngMin) * w; const y = h - (lat - B.latMin) / (B.latMax - B.latMin) * h; return {x,y}; }
  function add(r){ const p = project(r.lat, r.lng); const g = document.createElementNS(svgNS,'g'); const c = document.createElementNS(svgNS,'circle'); c.setAttribute('cx',p.x); c.setAttribute('cy',p.y); c.setAttribute('r',8); c.setAttribute('fill','#1db4ff'); c.setAttribute('stroke','#0a7aa5'); c.setAttribute('stroke-width','2'); const t = document.createElementNS(svgNS,'title'); t.textContent = `${r.nombre}\n${r.ciudad} — ${formatUSD(r.precio)}`; g.appendChild(c); g.appendChild(t); svg.appendChild(g); }
  DATA.reservas.forEach(add);
})();
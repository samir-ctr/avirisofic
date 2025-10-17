
(function(){
  function $(id){return document.getElementById(id)}
  const aves = window.DATA.aves;
  const grid = $('avesGrid');
  const fText = $('fText'), fCategoria=$('fCategoria'), fRegion=$('fRegion'), fEstado=$('fEstado'), pag=$('paginacion');
  const favKey='favAves';
  const cats=[...new Set(aves.map(a=>a.categoria))].sort(); cats.forEach(c=>fCategoria.append(new Option(c,c)));
  const regs=[...new Set(aves.map(a=>a.region))].sort();    regs.forEach(r=>fRegion.append(new Option(r,r)));
  let state={page:1, perPage:6, list: aves.slice(), favs: new Set(JSON.parse(localStorage.getItem(favKey)||'[]'))};

  function saveFavs(){ localStorage.setItem(favKey, JSON.stringify([...state.favs])); }

  // Simple modal implementation
  function openModal(a){
    const m = document.getElementById('birdModal');
    document.getElementById('bmTitle').textContent = a.nombre + ' — ' + a.cientifico;
    document.getElementById('bmImg').src = a.imagen;
    document.getElementById('bmInfo').innerHTML = `<div><strong>Región:</strong> ${a.region}</div>
      <div><strong>Hábitat:</strong> ${a.habitat}</div><div><strong>Estado:</strong> ${a.estado}</div>
      <div class="mt-2 text-muted">Ficha demostrativa sin fines científicos.</div>`;
    m.classList.add('show');
    m.querySelector('.btn-close').onclick=()=>m.classList.remove('show');
    m.addEventListener('click', (e)=>{ if(e.target.id==='birdModal') m.classList.remove('show'); });
  }

  function render(){
    grid.innerHTML='';
    const slice = state.list.slice((state.page-1)*state.perPage, state.page*state.perPage);
    if(!slice.length){ grid.innerHTML='<div class="col-12"><div class="card p-3">No hay resultados.</div></div>'; pag.innerHTML=''; return; }
    slice.forEach(a=>{
      const isFav = state.favs.has(a.id);
      const col = document.createElement('div'); col.className='col-md-6 col-lg-4';
      col.innerHTML = `<div class="card position-relative"><button class="btn-fav ${isFav?'active':''}" data-fav="${a.id}">★</button>
        <img class="card-img-top" src="${a.imagen}" alt="${a.nombre}"><div class="card-body">
        <h5 class="mb-1">${a.nombre}</h5><div class="small text-muted">${a.cientifico}</div>
        <div class="mt-2 small">📍 ${a.region}</div>
        <span class="badge bg-success-subtle text-success mt-2">${a.categoria}</span>
        <span class="badge bg-primary-subtle text-primary mt-2">${a.estado}</span>
        <div class="d-grid mt-2"><button class="btn btn-outline-primary btn-sm" data-detalle="${a.id}">Ver detalles</button></div>
        </div></div>`;
      grid.appendChild(col);
    });
    grid.querySelectorAll('[data-fav]').forEach(b=>b.onclick=()=>{const id=Number(b.dataset.fav); if(state.favs.has(id))state.favs.delete(id);else state.favs.add(id); saveFavs(); render();});
    grid.querySelectorAll('[data-detalle]').forEach(b=>b.onclick=()=>openModal(aves.find(x=>x.id==b.dataset.detalle)));

    // pagination
    const total = Math.max(1, Math.ceil(state.list.length/state.perPage));
    let html = `<button class="btn btn-outline-success btn-sm" data-p="${Math.max(1,state.page-1)}">Anterior</button>`;
    for(let i=1;i<=total;i++){ html += `<button class="btn btn-sm ${i===state.page?'btn-success':'btn-outline-success'}" data-p="${i}">${i}</button>`; }
    html += `<button class="btn btn-outline-success btn-sm" data-p="${Math.min(total,state.page+1)}">Siguiente</button>`;
    pag.innerHTML = html;
    pag.querySelectorAll('button').forEach(b=>b.onclick=()=>{state.page=Number(b.dataset.p); render();});
  }

  function apply(){
    const txt=(fText.value||'').toLowerCase().trim();
    let list=aves.slice();
    if(fCategoria.value) list=list.filter(a=>a.categoria===fCategoria.value);
    if(fRegion.value) list=list.filter(a=>a.region===fRegion.value);
    if(fEstado.value) list=list.filter(a=>a.estado===fEstado.value);
    if(txt) list=list.filter(a=>(a.nombre+' '+a.cientifico).toLowerCase().includes(txt));
    state.list=list; state.page=1; render();
  }

  document.getElementById('btnAplicar').onclick=apply;
  render();
})();

  const fSort = document.getElementById('fSort');
  const chipsFiltro = document.getElementById('chipsFiltro');
  function sortList(list){
    const v = fSort.value;
    if(v==='az') return list.sort((a,b)=>a.nombre.localeCompare(b.nombre));
    if(v==='za') return list.sort((a,b)=>b.nombre.localeCompare(a.nombre));
    if(v==='estado') return list.sort((a,b)=>a.estado.localeCompare(b.estado));
    return list;
  }
  function renderChips(){
    chipsFiltro.innerHTML='';
    [['Categoria',fCategoria.value],['Región',fRegion.value],['Estado',fEstado.value]].forEach(([k,v])=>{
      if(v) { const s=document.createElement('span'); s.className='chip active'; s.textContent=k+': '+v; chipsFiltro.appendChild(s); }
    });
  }
  const _render_old = render;
  render = function(){
    state.list = sortList(state.list);
    _render_old();
    renderChips();
  };

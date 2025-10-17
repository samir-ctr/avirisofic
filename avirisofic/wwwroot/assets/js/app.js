
// Datos de demo embebidos (offline)
window.DATA = {
  aves: [
    {id:1, nombre:"Guardabarranco", cientifico:"Eumomota superciliosa", region:"Región Central y Pacífico", habitat:"Bosque Tropical Seco", estado:"Nacional", categoria:"Motmot", imagen:"assets/img/ui1.jpg"},
    {id:2, nombre:"Tucán Pico Iris", cientifico:"Ramphastos sulfuratus", region:"Bosque Tropical Húmedo", habitat:"Selva tropical", estado:"Vulnerable", categoria:"Tucán", imagen:"assets/img/ui2.jpg"},
    {id:3, nombre:"Quetzal Resplandeciente", cientifico:"Pharomachrus mocinno", region:"Bosques Nubosos del Norte", habitat:"Bosque nuboso", estado:"Casi amenazado", categoria:"Trogón", imagen:"assets/img/ui3.jpg"},
    {id:4, nombre:"Colibrí Garganta de Rubí", cientifico:"Archilochus colubris", region:"Región Central", habitat:"Bosque", estado:"Migratorio", categoria:"Colibrí", imagen:"assets/img/ui4.jpg"},
    {id:5, nombre:"Águila Harpía", cientifico:"Harpia harpyja", region:"Bosque Atlántico", habitat:"Selva", estado:"En Peligro", categoria:"Rapaz", imagen:"assets/img/ui5.jpg"},
    {id:6, nombre:"Zanate Grande", cientifico:"Quiscalus mexicanus", region:"Todo el país", habitat:"Urbano", estado:"Residente", categoria:"Icterido", imagen:"assets/img/ui6.jpg"},
    {id:7, nombre:"Oropéndola de Montezuma", cientifico:"Psarocolius montezuma", region:"Bosques Húmedos", habitat:"Selva", estado:"Residente", categoria:"Icterido", imagen:"assets/img/ui7.jpg"},
    {id:8, nombre:"Reinita Azul", cientifico:"Setophaga cerulea", region:"Bosque del Norte", habitat:"Bosque templado", estado:"Vulnerable", categoria:"Parúlido", imagen:"assets/img/ui8.jpg"}
  ],
  reservas: [
    {id:1, nombre:"Reserva de Biosfera Bosawás", ciudad:"Jinotega", precio:45, lat:13.7, lng:-85.0, imagen:"assets/img/ui5.jpg"},
    {id:2, nombre:"Reserva Natural Laguna de Apoyo", ciudad:"Masaya", precio:35, lat:11.922, lng:-86.044, imagen:"assets/img/ui6.jpg"},
    {id:3, nombre:"Reserva Silvestre El Jaguar", ciudad:"Jinotega", precio:40, lat:13.217, lng:-86.047, imagen:"assets/img/ui7.jpg"},
    {id:4, nombre:"Reserva Natural Volcán Mombacho", ciudad:"Granada", precio:38, lat:11.829, lng:-85.967, imagen:"assets/img/ui8.jpg"},
    {id:5, nombre:"Refugio de Vida Silvestre Los Guatuzos", ciudad:"Río San Juan", precio:42, lat:11.0, lng:-84.9, imagen:"assets/img/ui4.jpg"}
  ],
  guias: [
    {id:1, nombre:"Elena Martínez", experiencia:8, tarifa:25, rating:4.8},
    {id:2, nombre:"Roberto Guzmán", experiencia:12, tarifa:30, rating:5.0},
    {id:3, nombre:"Ana Lucía Vega", experiencia:5, tarifa:22, rating:4.2}
  ],
  eventos: [
    {id:1, titulo:"Festival del Guardabarranco", fecha:"2025-10-12", lugar:"Reserva El Chocoyero"},
    {id:2, titulo:"Taller de Fotografía de Aves", fecha:"2025-10-20", lugar:"Reserva Miraflor"},
    {id:3, titulo:"Avistamiento Guiado de Aves", fecha:"2025-10-25", lugar:"Laguna de Apoyo"},
    {id:4, titulo:"Migración de Rapaces", fecha:"2025-11-02", lugar:"Volcán Mombacho"}
  ]
};

// Helpers
window.formatUSD = (n) => '$' + Number(n||0).toFixed(2) + ' USD';
window.getUser = () => { const raw = localStorage.getItem('user'); return raw ? JSON.parse(raw) : null; };
window.setUser = (user) => localStorage.setItem('user', JSON.stringify(user));
window.logout = () => { localStorage.removeItem('user'); location.href = 'login.html'; };

document.addEventListener('DOMContentLoaded', () => {
  const u = getUser();
  const badge = document.getElementById('userBadge');
  if (badge) badge.textContent = u ? u.nombre : 'Invitado';
});

// === Theme toggle (persist) ===
(function(){
  const THEME_KEY='themeMode';
  function set(mode){ document.documentElement.classList.toggle('light', mode==='light'); localStorage.setItem(THEME_KEY, mode); }
  function init(){ const saved=localStorage.getItem(THEME_KEY)||'light'; set(saved); const ctn=document.createElement('div'); ctn.className='theme-switch'; ctn.innerHTML='<button id="btnTheme">🌓</button>'; document.body.appendChild(ctn); document.getElementById('btnTheme').onclick=()=>{ const cur = document.documentElement.classList.contains('light')?'light':'dark'; set(cur==='light'?'dark':'light'); }; }
  if (document.readyState === 'loading') document.addEventListener('DOMContentLoaded', init); else init();
})();

// === Additional demo data fields ===
if(!window.DATA.hotspots){
  window.DATA.hotspots = [
    {nombre:'Bosawás', desc:'Reserva de biosfera y corredor biológico clave', mejor:'Nov–Feb', especies:['Águila harpía','Oropéndola'], lat:13.7, lng:-85.0},
    {nombre:'Laguna de Apoyo', desc:'Cráter volcánico con bosques secos y aves acuáticas', mejor:'Oct–Mar', especies:['Guardabarranco','Colibrí'], lat:11.922, lng:-86.044},
    {nombre:'El Jaguar', desc:'Café de sombra y bosque nuboso con alta diversidad', mejor:'May–Aug', especies:['Quetzal','Reinita'], lat:13.217, lng:-86.047},
  ];
}

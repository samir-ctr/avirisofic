/* BEGIN EXTERNAL SOURCE */

    // Cambiar tabs
    const tabLogin = document.getElementById('tabLogin');
    const tabRegister = document.getElementById('tabRegister');
    const loginBox = document.getElementById('loginBox');
    const registerBox = document.getElementById('registerBox');

    tabLogin.addEventListener('click', ()=>{
      tabLogin.classList.add('active'); tabRegister.classList.remove('active');
      loginBox.style.display='block'; registerBox.style.display='none';
    });
    tabRegister.addEventListener('click', ()=>{
      tabRegister.classList.add('active'); tabLogin.classList.remove('active');
      registerBox.style.display='block'; loginBox.style.display='none';
    });



    // Registrar
    document.getElementById('registerForm').addEventListener('submit', (e)=>{
      e.preventDefault();
      const u = {
        nombre: document.getElementById('nombre').value.trim(),
        apellido: document.getElementById('apellido').value.trim(),
        email: document.getElementById('email').value.trim().toLowerCase(),
        password: document.getElementById('regPassword').value,
        dob: document.getElementById('dob').value,
        origen: document.getElementById('origen').value.trim(),
        role: document.querySelector('input[name="role"]:checked').value,
        username: document.getElementById('email').value.split('@')[0]
      };

      const users = loadUsers();
      if(users.find(x=>x.email===u.email || x.username===u.username)){
        alert('Ya existe un usuario con ese correo o nombre de usuario.');
        return;
      }
      // NOTA: En producción, nunca guardar las contraseñas.
      users.push(u); saveUsers(users);
      alert('Cuenta creada correctamente. Ya puedes iniciar sesión.');
      // Volver al login
      tabLogin.click();
      document.getElementById('registerForm').reset();
    });


    // Botón cancelar registro
    document.getElementById('cancelRegister').addEventListener('click', ()=>{ tabLogin.click(); });

    // recupperar contraseña (demo)
    document.getElementById('forgotBtn').addEventListener('click', ()=>{
      const email = prompt('Introduce tu correo para recibir instrucciones (demo):');
      if(email) alert('Se ha (simulado) enviado un enlace de recuperación a '+email);
    });

  
/* END EXTERNAL SOURCE */

import React, { useState, useEffect, useRef } from 'react';
import Modal from 'react-modal';

Modal.setAppElement('#root');

function NotificationsPage() {
  const [notifications, setNotifications] = useState([]);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const modalRef = useRef();

  useEffect(() => {
    fetch('https://jsonplaceholder.typicode.com/posts?userId=1')
      .then((response) => response.json())
      .then((data) => setNotifications(data));
  }, []);

  useEffect(() => {
    const handleClickOutside = (e) => {
      if (modalRef.current && !modalRef.current.contains(e.target)) {
        setIsModalOpen(false);
      }
    };

    document.addEventListener('mousedown', handleClickOutside);

    return () => {
      document.removeEventListener('mousedown', handleClickOutside);
    };
  }, []);

  const toggleModal = () => {
    setIsModalOpen((prevState) => !prevState);
  };

  const clearNotifications = () => {
    setNotifications([]);
  };

  return (
    <div
      style={{
        fontFamily: 'Arial, sans-serif',
        background: '#f4f4f4',
        minHeight: '100vh',
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        justifyContent: 'center',
        padding: '20px',
      }}
    >
      <div
        style={{
          fontSize: '36px',
          fontWeight: '600',
          color: '#333',
          textAlign: 'center',
          padding: '40px',
          background: 'linear-gradient(135deg, rgba(255, 255, 255, 0.9), rgba(220, 220, 220, 0.7))',
          borderRadius: '12px',
          boxShadow: '0 8px 16px rgba(0, 0, 0, 0.2)',
          width: '600px',
          minHeight: '200px',
          marginBottom: '30px',
          border: '1px solid #ccd6e0',
          display: 'flex',
          flexDirection: 'column',
          justifyContent: 'center',
          alignItems: 'center',
        }}
      >
        <div
          style={{
            fontSize: '48px',
            fontWeight: '700',
            color: '#333',
            textAlign: 'center',
            marginBottom: '10px',
            letterSpacing: '2px',
            fontFamily: 'Arial, sans-serif',
            textShadow: '2px 2px 4px rgba(0, 0, 0, 0.1)',
            borderBottom: '4px solid #333',
            paddingBottom: '10px',
          }}
        >
          Bem-vindo!
        </div>
        <div
          style={{
            fontSize: '28px',
            color: '#333',
            textAlign: 'center',
            letterSpacing: '1px',
            fontFamily: 'Arial, sans-serif',
          }}
        >
          Você está na página de notificações
        </div>
      </div>

      <div
        onClick={toggleModal}
        style={{
          position: 'fixed',
          top: '10px',
          right: '20px',
          cursor: 'pointer',
          fontSize: '50px',
          color: '#FFD700',
        }}
      >
        🔔
      </div>

      {isModalOpen && (
        <div
          ref={modalRef}
          style={{
            position: 'fixed',
            top: '80px',
            right: '20px',
            backgroundColor: '#fff',
            width: '350px',
            maxHeight: '500px',
            overflowY: 'auto',
            boxShadow: '0 4px 10px rgba(0, 0, 0, 0.15)',
            padding: '20px',
            borderRadius: '12px',
            zIndex: 1000,
            fontFamily: 'Arial, sans-serif',
            transition: 'all 0.3s ease-in-out',
          }}
        >
          <h3 style={{ fontSize: '20px', color: '#333', marginBottom: '20px' }}>Notificações</h3>
          {notifications.length > 0 && (
            <button
              onClick={clearNotifications}
              style={{
                backgroundColor: '#28a745',
                color: '#fff',
                border: 'none',
                padding: '8px 12px',
                cursor: 'pointer',
                borderRadius: '5px',
                marginBottom: '20px',
                width: '100%',
                fontSize: '14px',
                transition: 'background-color 0.3s',
                boxShadow: '0 4px 6px rgba(0, 0, 0, 0.1)',
              }}
            >
              Limpar Todas Notificações
            </button>
          )}
          {notifications.length > 0 ? (
            notifications.map((notification) => (
              <div
                key={notification.id}
                style={{
                  backgroundColor: '#f8f9fa',
                  padding: '10px',
                  borderRadius: '5px',
                  marginBottom: '10px',
                  boxShadow: '0 2px 4px rgba(0, 0, 0, 0.1)',
                  cursor: 'pointer',
                  fontSize: '16px',
                  display: 'flex',
                  justifyContent: 'space-between',
                  alignItems: 'center',
                }}
              >
                <div>
                  <h4 style={{ fontSize: '16px', fontWeight: 'bold', color: '#333' }}>
                    {notification.title}
                  </h4>
                  <p style={{ fontSize: '14px', color: '#555' }}>
                    {notification.body}
                  </p>
                </div>
                <button
                  style={{
                    backgroundColor: 'transparent',
                    border: 'none',
                    color: '#dc3545',
                    cursor: 'pointer',
                    fontSize: '20px',
                    padding: '0',
                    marginLeft: '10px',
                  }}
                  onClick={(e) => {
                    e.stopPropagation();
                    setNotifications(notifications.filter((notif) => notif.id !== notification.id));
                  }}
                >
                  ✖
                </button>
              </div>
            ))
          ) : (
            <div
              style={{
                fontSize: '20px',
                color: '#333',
                textAlign: 'center',
                fontFamily: 'Arial, sans-serif',
              }}
            >
              Sem Notificações
            </div>
          )}
        </div>
      )}
    </div>
  );
}

export default NotificationsPage;

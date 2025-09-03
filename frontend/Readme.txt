frontend/
├── public/                    # Статичні файли (favicon, index.html)
├── src/
│   ├── api/                   # Запити до бекенду (axios, fetch), сервіси
│   ├── assets/                # Картинки, шрифти, іконки
│   ├── components/            # Повторно використовувані UI-компоненти (кнопки, інпути)
│   ├── hooks/                 # Кастомні React-хуки (useAuth, useForm тощо)
│   ├── layout/                # Лейаути (LandingLayout, DashboardLayout)
│   ├── pages/                 # Сторінки (LoginPage, DashboardPage, LandingPage)
│   ├── store/                 # Стан (Redux, Zustand, Context API)
│   ├── styles/                # Глобальні стилі, змінні, Tailwind config (якщо є)
│   ├── types/                 # Типи TypeScript, інтерфейси
│   ├── utils/                 # Утиліти, допоміжні функції
│   ├── App.tsx                # Кореневий компонент
│   └── main.tsx
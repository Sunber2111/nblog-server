import 'bootstrap/dist/css/bootstrap.min.css';
import '@/styles/index.scss';
import Navbar from '@/features/navbar';
import StyledComponentsRegistry from '@/lib/registry';

export default function RootLayout({ children }: { children: React.ReactNode }) {
  return (
    <html lang="en">
      <body>
        <StyledComponentsRegistry>
          <>
            <Navbar />
            {children}
          </>
        </StyledComponentsRegistry>
      </body>
    </html>
  );
}

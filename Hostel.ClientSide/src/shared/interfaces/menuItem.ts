export default interface MenuItem {
  icon: string;
  size: number;
  color: string;
  id: string;
  name: string;
  class?: string;
  callback: () => void;
}

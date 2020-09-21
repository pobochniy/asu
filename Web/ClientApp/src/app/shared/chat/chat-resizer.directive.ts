import { Directive, ElementRef, Renderer2, OnInit, HostListener, ViewChild, AfterViewInit, OnDestroy } from '@angular/core';

@Directive({
  selector: '[appChatResizer]'
})
export class ChatResizerDirective implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild('resizePanel', /* TODO: add static flag */ {}) panel: ElementRef;
  private el: any;
  private isDragabble = false;
  private startHeight = 0;
  private startHeightPosition = 0;

  constructor(
    private element: ElementRef,
    private renderer: Renderer2
  ) { }

  ngOnInit() {

  }

  ngAfterViewInit() {
    this.el = document.getElementById('resizePanel');
    this.el.addEventListener('mousedown', this.onDown.bind(this));
    this.el.addEventListener('mouseup', this.onUp.bind(this));
    document.addEventListener('mousemove', this.onMove.bind(this));
    this.startHeight = (this.element.nativeElement as HTMLElement).offsetHeight;
  }

  ngOnDestroy() {
    this.el.removeEventListener('mousedown');
    this.el.removeEventListener('mouseup');
  }
  
  onDown(e: MouseEvent) {
    this.isDragabble = true;
    this.startHeightPosition = e.pageY;
  }
  
  onUp(e) {
    this.isDragabble = false;
    this.startHeight = (this.element.nativeElement as HTMLElement).offsetHeight;
    this.startHeightPosition = e.pageY;
  }

  onMove(e) {
    if (this.isDragabble) {
      (this.element.nativeElement as HTMLElement).style.height = this.startHeight + this.startHeightPosition - e.pageY + 'px';
    }
  }

}
